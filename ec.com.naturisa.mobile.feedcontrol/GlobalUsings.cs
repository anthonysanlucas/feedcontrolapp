﻿global using System;
global using System.Collections.Generic;
global using System.Collections.ObjectModel;
global using System.Globalization;
global using System.Linq;
global using System.Text;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using System.Threading.Tasks;
global using CommunityToolkit.Maui;
global using CommunityToolkit.Maui.Alerts;
global using CommunityToolkit.Maui.Core;
global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input;
global using ec.com.naturisa.mobile.feedcontrol.Constants;
global using ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Models;
global using ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels;
global using ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Views;
global using ec.com.naturisa.mobile.feedcontrol.Features.Farm.Views;
global using ec.com.naturisa.mobile.feedcontrol.Features.Notifications.Views;
global using ec.com.naturisa.mobile.feedcontrol.Features.Profile.Views;
global using ec.com.naturisa.mobile.feedcontrol.Handlers;
global using ec.com.naturisa.mobile.feedcontrol.Helpers;
global using ec.com.naturisa.mobile.feedcontrol.Models;
global using ec.com.naturisa.mobile.feedcontrol.Models.Api;
global using ec.com.naturisa.mobile.feedcontrol.Models.Auth;
global using ec.com.naturisa.mobile.feedcontrol.Models.FeedTransfer;
global using ec.com.naturisa.mobile.feedcontrol.Services.Auth;
global using ec.com.naturisa.mobile.feedcontrol.Services.BaseHttp;
global using ec.com.naturisa.mobile.feedcontrol.Services.FeedControl.FeedTransferDetail;
global using ec.com.naturisa.mobile.feedcontrol.Services.FeedControl.FeedTransferDetailPool;
global using ec.com.naturisa.mobile.feedcontrol.Services.FeedTransfer;
global using ec.com.naturisa.mobile.feedcontrol.Services.Notifications;
global using ec.com.naturisa.mobile.feedcontrol.ViewModels;
global using ec.com.naturisa.mobile.feedcontrol.Views;
global using Microsoft.Extensions.Logging;
