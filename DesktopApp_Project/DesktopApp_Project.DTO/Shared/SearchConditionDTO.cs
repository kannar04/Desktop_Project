namespace DesktopApp_Project.DTO
{
    public class SearchConditionDTO
    {
        public string Field { get; set; }
        public object Value { get; set; }
        public SearchJoinOperator? JoinOperator { get; set; }
        public int OpenParentheses { get; set; }
        public int CloseParentheses { get; set; }
    }
}
