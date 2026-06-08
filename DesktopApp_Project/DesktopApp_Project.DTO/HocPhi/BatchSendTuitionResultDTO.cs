using System.Collections.Generic;

namespace DesktopApp_Project.DTO
{
    public class BatchSendTuitionResultDTO
    {
        public BatchSendTuitionResultDTO()
        {
            Items = new List<BatchSendTuitionItemResultDTO>();
        }

        public int TotalCount { get; set; }
        public int SuccessCount { get; set; }
        public int FailedCount { get; set; }
        public List<BatchSendTuitionItemResultDTO> Items { get; set; }
    }
}
