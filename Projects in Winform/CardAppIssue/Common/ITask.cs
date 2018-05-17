using System.Drawing;

namespace Common
{
    public interface ITask
    {
        long Id { get; set; }
        bool UpdateStatus(string state);
        string Error { get; }
        Bitmap CreateFrontCard();
        Bitmap CreateBackCard();
    }
}
