using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Davidix_Original_File_Downloader
{
    class Helper 
    {
        private ToolStripProgressBar prgbar;

        public ToolStripProgressBar ProgressbarDL
        {
            get { return prgbar; }
            set { prgbar = value; }
        }


        private bool _dlComplate;
        public string[] GetDirFiles(string Dir, string Filter,bool BaseFolder,bool GeneretForWeb,string WebSource)
        {
            string[] files;
            if (string.IsNullOrEmpty(Filter))
                Filter = "*.*";
            if (Directory.Exists(Dir))
            {
                files = Directory.GetFiles(Dir, Filter, SearchOption.AllDirectories);
                if (!BaseFolder || GeneretForWeb || !string.IsNullOrEmpty(WebSource))
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (!BaseFolder) { files[i] = files[i].Replace(Dir, ""); }
                        if (GeneretForWeb) { files[i] = files[i].Replace(@"\",@"/"); }
                        if (!string.IsNullOrEmpty(WebSource)) { files[i] =WebSource+files[i].Replace(@"\", @"/"); }
                    }
                }
                return files;
            }
            else
                return null;
        }
        
        public  async Task Download(string Uri,string Location)
        {
        _dlComplate = false;
            using (var webClient = new WebClient())
            {
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                try
                {
                    await webClient.DownloadFileTaskAsync(new Uri(Uri), Location);
                }
                catch (Exception eX)
                {
                  //  MessageBox.Show(eX.Message);
                }
            }
    
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            prgbar.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            _dlComplate = true;
        }
    }
}