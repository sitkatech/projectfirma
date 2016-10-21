using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.Snapshot
{
    public class EditViewModel : FormViewModel
    {
        [Required]
        public int SnapshotID { get; set; }

        [DisplayName("Snapshot Note")]
        public string SnapshotNote { get; set; }

        public EditViewModel() {}

        public EditViewModel(Models.Snapshot snapshot)
        {
            SnapshotID = snapshot.SnapshotID;
            SnapshotNote = snapshot.SnapshotNote;
        }

        public void UpdateModel(Models.Snapshot snapshot, Person currentPerson)
        {
            snapshot.SnapshotNote = SnapshotNote;
        }
    }
}