using System;
using System.Collections.Generic;
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

namespace UniverseSimulator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly Random _random = new Random();
    
    // 数据库
    private readonly List<string> _planets = new List<string>
    {
        "水蓝星", "赤焰星", "翠绿星", "紫晶星", "金辉星", "银月星", "黑洞星", "霜冻星", "熔岩星", "气态巨星",
        "岩石星", "双星系统", "三星系统", "环形星系", "椭圆星系", "螺旋星系", "不规则星系", "矮星系", "中子星", "脉冲星"
    };
    
    private readonly List<string> _species = new List<string>
    {
        "碳基人类", "硅基生命", "能量体", "机械智能", "水生智慧种族", "气态生命体", "晶体生命", "菌类集群意识", 
        "昆虫类群体智能", "植物智慧体", "多维度生命", "量子意识体", "纳米机械群", "混合生物机械体", "病毒智能体",
        "岩石生命", "等离子体生命", "暗物质生命", "时间游离者", "跨维度存在"
    };
    
    private readonly List<string> _techLevels = new List<string>
    {
        "0级 - 原始文明（使用简单工具）", 
        "1级 - 农业文明（发展农业和畜牧）", 
        "2级 - 工业文明（蒸汽和电力）", 
        "3级 - 信息文明（计算机和互联网）", 
        "4级 - 行星文明（全球统一和环境控制）", 
        "5级 - 星系文明（行星间旅行和殖民）", 
        "6级 - 恒星文明（恒星能源利用）", 
        "7级 - 星系群文明（跨星系旅行和通信）", 
        "8级 - 超维度文明（操控时空）", 
        "9级 - 宇宙文明（掌控宇宙规律）"
    };
    
    private readonly List<string> _civilizationEvents = new List<string>
    {
        "经历了三次全球战争后，终于实现了和平统一",
        "通过宗教信仰凝聚了全球意识，形成了神权统治",
        "发展出高度自动化社会，大部分个体沉浸在虚拟现实中",
        "进化出集体意识，个体思想可以自由连接和分离",
        "与其他文明建立了星际联盟，共享科技和资源",
        "发现了意识上传技术，生命形式转变为数字存在",
        "改造了自身基因，适应了极端环境生存",
        "创造了人工智能，最终与之融合成为新物种",
        "掌握了反物质能源，实现了星际殖民",
        "发现了多维度空间，建立了跨维度文明网络",
        "通过量子通信实现了即时星际交流",
        "发展出心灵感应能力，不再需要语言交流",
        "建造了戴森球，完全利用恒星能量",
        "发现了永生技术，平均寿命达到数千年",
        "创造了微型宇宙，成为了造物主"
    };
    
    private readonly List<string> _extinctionReasons = new List<string>
    {
        "星球核心不稳定，导致行星解体",
        "自我毁灭性战争，文明彻底覆灭",
        "人工智能反叛，消灭了创造者",
        "资源枯竭，无法维持文明运转",
        "遭遇高级文明入侵，被彻底征服",
        "基因改造失控，导致物种灭绝",
        "病毒突变，无法找到解药",
        "气候剧变，环境不再适合生存",
        "社会结构崩溃，陷入永久混乱",
        "科技实验事故，引发不可逆转的灾难",
        "恒星爆发超新星，摧毁整个行星系",
        "黑洞吞噬，整个星系消失",
        "维度坍塌，现实结构被破坏",
        "集体意识分裂，文明自我瓦解",
        "进化停滞，无法适应环境变化",
        "宗教极端主义，放弃科技发展",
        "遭遇宇宙自然灾害，如伽马射线暴",
        "文明自我升华，放弃物质形态",
        "能源危机，无法维持基本生存",
        "与平行宇宙碰撞，现实结构崩溃"
    };

    public MainWindow()
    {
        InitializeComponent();
    }

    private void GenerateButton_Click(object sender, RoutedEventArgs e)
    {
        // 生成随机结果
        string planet = GetRandomItem(_planets);
        string species = GetRandomItem(_species);
        string techLevel = GetRandomItem(_techLevels);
        string civilizationEvent = GetRandomItem(_civilizationEvents);
        string extinctionReason = GetRandomItem(_extinctionReasons);

        // 显示结果
        PlanetText.Text = planet;
        SpeciesText.Text = species;
        TechLevelText.Text = techLevel;
        CivilizationText.Text = civilizationEvent;
        ExtinctionText.Text = extinctionReason;
        
        // 显示结果区域
        ResultText.Text = $"在遥远的宇宙中，一个文明的故事...";
        ResultGrid.Visibility = Visibility.Visible;
    }

    private string GetRandomItem(List<string> items)
    {
        int index = _random.Next(items.Count);
        return items[index];
    }
}