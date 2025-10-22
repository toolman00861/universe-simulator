using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using UniverseSimulator.Models;

namespace UniverseSimulator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly Random _random = new Random();
    private UniverseData? _universeData;

    public MainWindow()
    {
        InitializeComponent();
        LoadUniverseData();
    }

    private void LoadUniverseData()
    {
        try
        {
            string jsonPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "UniverseData.json");
            if (File.Exists(jsonPath))
            {
                string jsonContent = File.ReadAllText(jsonPath);
                _universeData = JsonConvert.DeserializeObject<UniverseData>(jsonContent);
            }
            else
            {
                MessageBox.Show("数据文件未找到，将使用默认数据。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                LoadDefaultData();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"加载数据文件时出错：{ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            LoadDefaultData();
        }
    }

    private void LoadDefaultData()
    {
        // 如果JSON文件加载失败，使用默认数据
        _universeData = new UniverseData
        {
            Planets = new List<Planet>
            {
                new Planet { Name = "水蓝星", Type = "类地行星", Description = "一颗被蔚蓝海洋覆盖的美丽星球" }
            },
            Species = new List<Species>
            {
                new Species { Name = "碳基人类", Type = "碳基生命", Description = "以碳为基础的智慧生命" }
            },
            TechLevels = new List<TechLevel>
            {
                new TechLevel { Level = 0, Name = "原始文明", Description = "使用简单工具" }
            },
            CivilizationEvents = new List<CivilizationEventCategory>
            {
                new CivilizationEventCategory 
                { 
                    Category = "默认", 
                    Events = new List<string> { "发展出了基本的文明形态" } 
                }
            },
            ExtinctionReasons = new List<ExtinctionReasonCategory>
            {
                new ExtinctionReasonCategory 
                { 
                    Category = "默认", 
                    Reasons = new List<string> { "未知原因导致文明消失" } 
                }
            }
        };
    }

    private void GenerateButton_Click(object sender, RoutedEventArgs e)
    {
        if (_universeData == null)
        {
            MessageBox.Show("数据未加载，无法生成文明。", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        // 生成随机文明
        var civilization = GenerateRandomCivilization();

        // 显示结果
        DisplayCivilization(civilization);
    }

    private GeneratedCivilization GenerateRandomCivilization()
    {
        var civilization = new GeneratedCivilization();

        // 随机选择星球
        if (_universeData!.Planets.Any())
        {
            civilization.Planet = GetRandomItem(_universeData.Planets);
        }

        // 随机选择种族
        if (_universeData.Species.Any())
        {
            civilization.Species = GetRandomItem(_universeData.Species);
        }

        // 随机选择科技等级
        if (_universeData.TechLevels.Any())
        {
            civilization.TechLevel = GetRandomItem(_universeData.TechLevels);
        }

        // 随机选择文明事件
        if (_universeData.CivilizationEvents.Any())
        {
            var eventCategory = GetRandomItem(_universeData.CivilizationEvents);
            civilization.EventCategory = eventCategory.Category;
            if (eventCategory.Events.Any())
            {
                civilization.CivilizationEvent = GetRandomItem(eventCategory.Events);
            }
        }

        // 随机选择灭亡原因
        if (_universeData.ExtinctionReasons.Any())
        {
            var extinctionCategory = GetRandomItem(_universeData.ExtinctionReasons);
            civilization.ExtinctionCategory = extinctionCategory.Category;
            if (extinctionCategory.Reasons.Any())
            {
                civilization.ExtinctionReason = GetRandomItem(extinctionCategory.Reasons);
            }
        }

        return civilization;
    }

    private void DisplayCivilization(GeneratedCivilization civilization)
    {
        // 更新基本信息
        PlanetText.Text = $"{civilization.Planet.Name} ({civilization.Planet.Type})";
        SpeciesText.Text = $"{civilization.Species.Name} - {civilization.Species.Type}";
        TechLevelText.Text = $"{civilization.TechLevel.Level}级 - {civilization.TechLevel.Name}";
        CivilizationText.Text = civilization.CivilizationEvent;
        ExtinctionText.Text = civilization.ExtinctionReason;

        // 更新详细信息
        PlanetDetailText.Text = $"大小：{civilization.Planet.Size}\n" +
                               $"大气：{civilization.Planet.Atmosphere}\n" +
                               $"气候：{civilization.Planet.Climate}\n" +
                               $"描述：{civilization.Planet.Description}";

        SpeciesDetailText.Text = $"智慧类型：{civilization.Species.Intelligence}\n" +
                                $"生理结构：{civilization.Species.Physiology}\n" +
                                $"寿命：{civilization.Species.Lifespan}\n" +
                                $"特征：{string.Join("、", civilization.Species.Traits)}\n" +
                                $"描述：{civilization.Species.Description}";

        TechDetailText.Text = $"主要成就：{string.Join("、", civilization.TechLevel.Achievements)}\n" +
                             $"能源：{civilization.TechLevel.Energy}\n" +
                             $"通信：{civilization.TechLevel.Communication}\n" +
                             $"交通：{civilization.TechLevel.Transportation}\n" +
                             $"人口规模：{civilization.TechLevel.Population}";

        EventCategoryText.Text = civilization.EventCategory;
        ExtinctionCategoryText.Text = civilization.ExtinctionCategory;

        // 显示结果区域
        ResultText.Text = "在遥远的宇宙中，一个文明的完整故事...";
        ResultGrid.Visibility = Visibility.Visible;
    }

    private T GetRandomItem<T>(List<T> items)
    {
        if (!items.Any())
            throw new InvalidOperationException("列表为空");
        
        int index = _random.Next(items.Count);
        return items[index];
    }
}