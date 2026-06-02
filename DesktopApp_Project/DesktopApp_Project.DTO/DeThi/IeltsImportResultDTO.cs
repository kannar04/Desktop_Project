using System.Collections.Generic;

namespace DesktopApp_Project.DTO
{
    public class IeltsImportResultDTO
    {
        public int PassageCount { get; set; }
        public int SectionCount { get; set; }
        public int QuestionCount { get; set; }
        public List<string> Errors { get; set; }

        public IeltsImportResultDTO()
        {
            Errors = new List<string>();
        }
    }
}
