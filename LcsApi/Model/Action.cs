namespace LcsApi.Model
{
    public class Action
    {
        public int CategoryType { get; set; }
        public bool HasVisibleChildren { get; set; }
        public int Id { get; set; }
        public string? Label { get; set; }
        public bool IsVisible { get; set; }
        public string? Name { get; set; }
        public Action[]? Children { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Description { get; set; }
        public bool IsDisruptive { get; set; }
        public string? LabelResxKey { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ServiceId { get; set; }
        public bool ShowHistory { get; set; }
        public Action? ParentAction { get; set; }
        public int? ParentActionId { get; set; }
    }

}