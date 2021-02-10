using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Mew.AppLogAndEventHelper.Helpers;

namespace ScreenshotsForCasinos {
    public class Casino : CasinoRecord {
        private DirectoryInfo di_;

        public Casino() { }

        public Casino(int id, string domain, string datadir = "") : base(id, domain) {
            if (string.IsNullOrWhiteSpace(datadir)) return;

            this.di_ = new DirectoryInfo(Path.Join(datadir, $"{this.Domain}\\"));
            this.Directory = this.di_.FullName;
        }

        public void LazyInit() {
            Debug.Assert(this.di_ != null);
            if (this.di_.Exists) return;

            //this.di_ = datadir.CreateSubdirectory($"{this.Domain}\\");
            this.di_.Create();
            this.Directory = this.di_.FullName;
        }

        public bool ScreenshotExists(string screenshot_type) {
            if (this.Screenshots.ContainsKey(screenshot_type) && !string.IsNullOrWhiteSpace(this.Screenshots[screenshot_type]))
                return new FileInfo(this.Screenshots[screenshot_type]).Exists;

            var path = this.ScreenshotPath(screenshot_type);
            return this.AddScreenshot(screenshot_type, path);
        }

        public string GetScreenshotPath(string name) {
            if (!this.Screenshots.ContainsKey(name) || string.IsNullOrWhiteSpace(this.Screenshots[name]) || !new FileInfo(this.Screenshots[name]).Exists) return "";
            return this.Screenshots[name];
        }

        public bool AddScreenshot(string screenshot_type, string path) {
            if (!new FileInfo(path).Exists) return false;
            if (this.Screenshots.ContainsKey(screenshot_type))
                this.Screenshots[screenshot_type] = path;
            else
                this.Screenshots.Add(screenshot_type, path);

            return true;
        }

        public string ScreenshotPath(string screenshot_type) =>
            this.di_.GetFile($"{this.Domain}_{screenshot_type}.png").FullName;

        public static Casino FromCasinoRecord(CasinoRecord cr) {
            var record = new Casino(int.Parse(cr.ID), cr.Domain);
            record.Screenshots = cr.Screenshots;
            record.Directory = cr.Directory;

            if(!string.IsNullOrWhiteSpace(cr.Directory)) record.di_ = new DirectoryInfo(cr.Directory);

            return record;
        }
    }

    public class CasinoRecord {
        public string ID { get; set; }
        public string Domain { get; set; }
        public string Directory { get; set; }
        public Dictionary<string, string> Screenshots { get; set; }

        public CasinoRecord() { }

        public CasinoRecord(int id, string domain) {
            this.ID = id.ToString();
            this.Domain = domain;
            this.Screenshots = new Dictionary<string, string>();
        }

        public override string ToString() =>
            $"{this.ID};{this.Domain};{this.Directory};" +
            $"{this.Screenshots.Count};";
    }
}