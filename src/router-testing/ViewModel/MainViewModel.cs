﻿using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_router.core;
using wpf_router.core.impl;

namespace Wpf_Router.ViewModel
{
    public partial class MainViewModel
    {
        private IWpfRouter router = WpfRouter.Instance;
        [RelayCommand]
        public void AddClick()
        {
            router.NavicatTo("/home/page1");
        }
    }
}
