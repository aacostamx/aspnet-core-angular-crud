using System.Collections.Generic;
using System.Linq;

namespace Lauderdale.Domain.Operator
{
    public class OperationResult
    {
        public List<NoteItem> Notes { get; set; } = new List<NoteItem>();

        public static OperationResult Success => new OperationResult().Add("Success!", "Success!", NoteType.success);

        public bool IsSuccess => Notes.All(n => n.Type == NoteType.none ||
                                                n.Type == NoteType.success ||
                                                n.Type == NoteType.info);

        public OperationResult Warn(string description, string title = "Ops")
        {
            Notes.Add(NoteItem.New(title, description, NoteType.warning));
            return this;
        }

        public OperationResult Add(string title, string description, NoteType type)
        {
            Notes.Add(NoteItem.New(title, description, NoteType.warning));
            return this;
        }

        public static OperationResult Alert(string title, string description, NoteType type)
        {
            return new OperationResult().Add(title, description, type);
        }
    }
}
