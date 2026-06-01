using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DesktopApp_Project.BUS;
using DesktopApp_Project.Common;
using DesktopApp_Project.DTO;

namespace DesktopApp_Project.GUI
{
    public partial class FrmFlashcard : ModuleFormBase
    {
        private readonly Random _random = new Random();
        private List<TuVungDTO> _cards = new List<TuVungDTO>();
        private int _currentIndex;
        private bool _showBack;
        private bool _isLoading;

        public FrmFlashcard()
        {
            InitializeComponent();
            WireEvents();
        }

        public FrmFlashcard(ServiceFactory services, NguoiDungDTO currentUser)
            : this()
        {
            SetRuntimeContext(services, currentUser);
        }

        private void WireEvents()
        {
            WireClick(btnLatThe, BtnLatThe_Click);
            WireClick(btnTiepTheo, BtnTiepTheo_Click);
            WireClick(btnTruoc, BtnTruoc_Click);
            WireClick(btnXaoTron, BtnXaoTron_Click);
            WireSelectedIndexChanged(_cboLop, Filter_Changed);
            WireSelectedIndexChanged(_cboCapDo, Filter_Changed);
            WireSelectedIndexChanged(_cboChuDe, Filter_Changed);
        }

        protected override void OnRuntimeLoad()
        {
            _isLoading = true;
            try
            {
                UiHelpers.BindLopHoc(_cboLop, Services);
                _cboCapDo.DataSource = new[] { AppConstants.FilterAll }.Concat(AppConstants.CefrLevels).ToList();
                _cboChuDe.DataSource = new[] { AppConstants.FilterAll }.Concat(AppConstants.VocabularyTopics).ToList();
            }
            finally
            {
                _isLoading = false;
            }

            LoadCards();
        }

        private void LoadCards()
        {
            if (!CanUseServices || _isLoading)
            {
                return;
            }

            var result = Services.TuVung.LayDanhSachFlashcard(new TuVungSearchCriteriaDTO
            {
                MaLopHoc = UiHelpers.SelectedId(_cboLop),
                CapDo = SelectedFilter(_cboCapDo),
                ChuDe = SelectedFilter(_cboChuDe),
                TuLoai = AppConstants.FilterAll,
                ChuCaiDau = AppConstants.FilterAll
            });

            if (!result.Success)
            {
                UiHelpers.ShowResult(result);
                _cards = new List<TuVungDTO>();
            }
            else
            {
                _cards = result.Data ?? new List<TuVungDTO>();
            }

            _currentIndex = 0;
            _showBack = false;
            DisplayCard();
        }

        private void DisplayCard()
        {
            var hasCards = _cards.Count > 0;
            btnLatThe.Enabled = hasCards;
            btnXaoTron.Enabled = hasCards;
            btnTruoc.Enabled = hasCards && _currentIndex > 0;
            btnTiepTheo.Enabled = hasCards && _currentIndex < _cards.Count - 1;
            lblCounter.Text = hasCards ? (_currentIndex + 1).ToString("N0") + " / " + _cards.Count.ToString("N0") : "0 / 0";

            if (!hasCards)
            {
                lblSide.Text = "Flashcard";
                lblCardTitle.Text = "Chua co tu vung";
                lblCardValue.Text = "Them tu vung hoac chon bo loc khac.";
                lblCardMeta.Text = string.Empty;
                return;
            }

            var card = _cards[_currentIndex];
            lblSide.Text = _showBack ? "Nghia" : "Tu vung";
            if (_showBack)
            {
                lblCardTitle.Text = SafeText(card.Nghia);
                lblCardValue.Text = SafeText(card.TuTiengAnh);
            }
            else
            {
                lblCardTitle.Text = SafeText(card.TuTiengAnh);
                lblCardValue.Text = SafeText(card.PhienAm);
            }

            lblCardMeta.Text = SafeText(card.TuLoai) + "  |  " + SafeText(card.CapDo) + "  |  " + SafeText(card.ChuDe);
        }

        private void BtnLatThe_Click(object sender, EventArgs e)
        {
            if (_cards.Count == 0)
            {
                return;
            }

            _showBack = !_showBack;
            if (_showBack && CurrentUser != null)
            {
                var result = Services.TuVung.GhiNhanFlashcardDaHoc(CurrentUser.MaNguoiDung, _cards[_currentIndex].MaTuVung);
                if (!result.Success)
                {
                    UiHelpers.ShowResult(result);
                }
            }

            DisplayCard();
        }

        private void BtnTiepTheo_Click(object sender, EventArgs e)
        {
            if (_currentIndex < _cards.Count - 1)
            {
                _currentIndex++;
                _showBack = false;
                DisplayCard();
            }
        }

        private void BtnTruoc_Click(object sender, EventArgs e)
        {
            if (_currentIndex > 0)
            {
                _currentIndex--;
                _showBack = false;
                DisplayCard();
            }
        }

        private void BtnXaoTron_Click(object sender, EventArgs e)
        {
            if (_cards.Count <= 1)
            {
                return;
            }

            _cards = _cards.OrderBy(x => _random.Next()).ToList();
            _currentIndex = 0;
            _showBack = false;
            DisplayCard();
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            LoadCards();
        }

        private static string SelectedFilter(ComboBox combo)
        {
            var value = combo == null ? null : Convert.ToString(combo.SelectedItem);
            return string.IsNullOrWhiteSpace(value) ? AppConstants.FilterAll : value;
        }

        private static string SafeText(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? "-" : value.Trim();
        }
    }
}
