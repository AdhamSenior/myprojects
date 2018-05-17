using System;
using System.Windows.Forms;

namespace Common
{
    public partial class PagingControl : UserControl
    {
        public event EventHandler CurrentPageChanged;

        private decimal _totalRecords;
        public decimal TotalRecords
        {
            get { return _totalRecords; }
            set
            {
                _totalRecords = value;
                UpdateText();
            }
        }

        private decimal _pageSize;
        public decimal PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value;
                UpdateText();
            }
        }

        private decimal _currentPage;
        public decimal CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                UpdateText();
            }

        }
        public decimal PageCount
        {
            get
            {
                if (PageSize == 0)
                    return 0;
                return Math.Ceiling(TotalRecords / PageSize);
            }
        }
        public PagingControl()
        {
            InitializeComponent();

            PageSize = 25;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode)
                return;

            kbtnFirst.Click += kbtnFirst_Click;
            kbtnLast.Click += kbtnLast_Click;
            kbtnNext.Click += kbtnNext_Click;
            kbtnPrevious.Click += kbtnPrevious_Click;
        }

        void kbtnPrevious_Click(object sender, EventArgs e)
        {
            if (CurrentPage == PageCount)
                CurrentPage = PageCount - 1;

            CurrentPage--;
            if (CurrentPage < 0)
                CurrentPage = 0;

            if (!ReferenceEquals(CurrentPageChanged, null))
                CurrentPageChanged.Invoke(sender, e);
        }

        void kbtnNext_Click(object sender, EventArgs e)
        {
            CurrentPage++;
            if (CurrentPage > (PageCount - 1))
                CurrentPage = PageCount - 1;
            if (CurrentPage < 0)
                CurrentPage = 0;

            if (!ReferenceEquals(CurrentPageChanged, null))
                CurrentPageChanged.Invoke(sender, e);
        }

        void kbtnLast_Click(object sender, EventArgs e)
        {
            CurrentPage = PageCount - 1;
            if (CurrentPage < 0)
                CurrentPage = 0;
            if (!ReferenceEquals(CurrentPageChanged, null))
                CurrentPageChanged.Invoke(sender, e);
        }

        void kbtnFirst_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            if (!ReferenceEquals(CurrentPageChanged, null))
                CurrentPageChanged.Invoke(sender, e);
        }

        void UpdateText()
        {
            var txt = String.Format("{0} / {1}", CurrentPage + 1, PageCount);
            if (PageCount == 0)
                txt = "0 / 0";
            ktbPage.Text = txt;
        }
    }
}
