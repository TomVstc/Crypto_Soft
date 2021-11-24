using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;

namespace Livrable
{
    class ViewStateLog : ViewDailyLog
    {

        #region ALL ATTRIBUTE
        // ALL ATTRIBUTE OF VIEW STATELOG
        private string backupState;
        private int totalFileToCopy;
        private long totalFilesSize;
        private int nbFilesLeftToDo;
        private int fileSizeLeftToDo;
        #endregion

        #region SET/GET
        public string BackupState
        {
            get { return backupState; }
            set { backupState = value; }
        }
        public int TotalFileToCopy
        {
            get { return totalFileToCopy; }
            set { totalFileToCopy = value; }
        }
        public long TotalFileSize
        {
            get { return totalFilesSize; }
            set { totalFilesSize = value; }
        }
        public int NbFilesLeftToDo
        {
            get { return nbFilesLeftToDo; }
            set { nbFilesLeftToDo = value; }
        }
        public int FileSizeLeftToDo
        {
            get { return fileSizeLeftToDo; }
            set { fileSizeLeftToDo = value; }
        }
        #endregion

        public ViewStateLog()
        {
            BackupState = "";
            TotalFileToCopy = 0;
            TotalFileSize = 0;
            NbFilesLeftToDo = 0;
            FileSizeLeftToDo = 0;
        }
    }
}
