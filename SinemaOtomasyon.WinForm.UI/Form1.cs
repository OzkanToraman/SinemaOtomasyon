using Ninject;
using SinemaOtomasyon.BLL.Services.Abstract;
using SinemaOtomasyon.BLL.Services.Concrete;
using SinemaOtomasyon.BLL.Services.Validations;
using SinemaOtomasyon.DAL.SinemaContext;
using SinemaOtomasyon.Repository.Repositories.Abstracts;
using SinemaOtomasyon.Repository.Repositories.Concretes;
using SinemaOtomasyon.WinForm.UI.Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinemaOtomasyon.WinForm.UI
{
    public partial class Form1 : Form
    {
        private readonly IFilmService _service;
        private readonly IFilmRepository _filmRepo;
        private readonly IPersonelService _personelService;
        private readonly IPersonelRepository _personelRepo;

        public Form1()
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _service = container.Get<IFilmService>();
            _personelRepo = container.Get<IPersonelRepository>();
            _personelService = container.Get<IPersonelService>();
            _filmRepo = container.Get<IFilmRepository>();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _filmRepo.GetList();            
        }

    }
}
