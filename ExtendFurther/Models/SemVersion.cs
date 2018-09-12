using System.Text.RegularExpressions;

namespace ExtendIt
{
    public class SemVersion
    {
        private bool IsValid => (MajorVersion + MinorVersion + PatchVersion > 0);

        public string Version { get; }
        public int MajorVersion { get; }
        public int MinorVersion { get; }
        public int PatchVersion { get; }
        public bool IsGreaterThan(SemVersion ver) => CompareTo(ver) == 1;
        public bool IsLessThan(SemVersion ver) => CompareTo(ver) == -1;

        public SemVersion(string Version)
        {

            try
            {
                this.Version = Regex.Match(Version ?? string.Empty, @"\d+.\d+.\d+")?.Value;

                MajorVersion = int.Parse(this.Version.Split('.')[0]);
                MinorVersion = int.Parse(this.Version.Split('.')[1]);
                PatchVersion = int.Parse(this.Version.Split('.')[2]);

            }
            catch
            {
                this.Version = Version;
                MajorVersion = MinorVersion = PatchVersion = 0;
            }

        }

        public int CompareTo(SemVersion ver)
        {
            if (ver.IsValid == false || IsValid == false)
                return -2;

            else if ((ver.IsValid && IsValid) && (ver.MajorVersion == MajorVersion && ver.MinorVersion == MinorVersion && ver.PatchVersion == PatchVersion))
                return 0;

            else if ((ver.IsValid && IsValid) && (ver.MajorVersion < MajorVersion || (ver.MajorVersion == MajorVersion && ver.MinorVersion < MinorVersion) || (ver.MajorVersion == MajorVersion && ver.MinorVersion == MinorVersion && ver.PatchVersion < PatchVersion)))
                return 1;

            else if ((ver.IsValid && IsValid) && (ver.MajorVersion > MajorVersion || (ver.MajorVersion == MajorVersion && ver.MinorVersion > MinorVersion) || (ver.MajorVersion == MajorVersion && ver.MinorVersion == MinorVersion && ver.PatchVersion > PatchVersion)))
                return -1;

            else return -2;
        }

    }
}