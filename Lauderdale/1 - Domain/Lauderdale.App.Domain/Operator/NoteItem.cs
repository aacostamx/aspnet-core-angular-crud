namespace Lauderdale.Domain.Operator
{
    public class NoteItem
    {
        public static NoteItem New(string title, string description, NoteType type)
        {
            return new NoteItem()
            {
                Title = title,
                Description = description,
                Type = type
            };
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public NoteType Type { get; private set; }
    }
}
