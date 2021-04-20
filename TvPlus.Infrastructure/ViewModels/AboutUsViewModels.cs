using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FluentValidation;
using TvPlus.Core.Models;

namespace TvPlus.Infrastructure.ViewModels
{
    public class AboutUsViewModel
    {
        public AboutUs AboutUs { get; set; }
        private List<AboutUsSection> _aboutUsSections;

        public List<AboutUsSection> AboutUsSections
        {
            get { return _aboutUsSections ?? (_aboutUsSections = new List<AboutUsSection>()); }
            set { _aboutUsSections = value; }
        }
    }
}
