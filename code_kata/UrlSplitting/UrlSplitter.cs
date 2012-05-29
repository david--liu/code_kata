namespace code_kata.UrlSplitting
{
    public class UrlSplitter
    {
        private readonly string url;

        private string protocol = string.Empty;
        private string domain = string.Empty;
        private string path = string.Empty;

        public UrlSplitter(string url)
        {
            this.url = url;
            Split();
        }

        public string Protocol
        {
            get { return protocol; }
        }

        public string Domain
        {
            get { return domain; }
        }

        public string Path
        {
            get
            {
                var split = url.Split(':');
                if (split.Length > 1)
                {
                    var strings = split[1].Split('/');

                    if (strings.Length > 3)
                        return strings[3];
                }

                return string.Empty;
            }
        }

        private void Split()
        {
            var split = url.Split(':');
            if (split.Length > 1)
            {
                protocol = split[0];

                var strings = split[1].Split('/');

                if(strings.Length > 2)
                {
                    domain = strings[2];
                }
                
                if (strings.Length > 3)
                {
                    path = strings[3];
                }
            }
        }
    }
}