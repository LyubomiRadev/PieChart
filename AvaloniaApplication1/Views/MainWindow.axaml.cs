using Avalonia.Controls;

using OxyPlot.Series;
using OxyPlot;
using System.Collections.ObjectModel;

namespace AvaloniaApplication1.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

		var plotModel = new PlotModel { Title = "World population by continent" };
		var pieSeries = new PieSeries() { TextColor = OxyColors.BlueViolet };
		pieSeries.Slices.Add(new PieSlice("Africa", 1030) { IsExploded = true });
		pieSeries.Slices.Add(new PieSlice("Americas", 929) { IsExploded = true });
		pieSeries.Slices.Add(new PieSlice("Asia", 4157));
		pieSeries.Slices.Add(new PieSlice("Europe", 739) { IsExploded = true });
		pieSeries.Slices.Add(new PieSlice("Oceania", 35) { IsExploded = true });
		pieSeries.InnerDiameter = 0.2;
		pieSeries.ExplodedDistance = 0;
		pieSeries.Stroke = OxyColors.Black;
		pieSeries.StrokeThickness = 1.0;
		pieSeries.AngleSpan = 360;
		pieSeries.StartAngle = 0;
		plotModel.Series.Add(pieSeries);

		Continents = new ObservableCollection<ContinentItem>
		{
			new ContinentItem { Name = "Africa", PopulationInMillions = 1030, IsExploded = true },
			new ContinentItem { Name = "Americas", PopulationInMillions = 929, IsExploded = true },
			new ContinentItem { Name = "Asia", PopulationInMillions = 4157 },
			new ContinentItem { Name = "Europe", PopulationInMillions = 739, IsExploded = true },
			new ContinentItem { Name = "Oceania", PopulationInMillions = 35, IsExploded = true }
		};

		this.PieModel = plotModel;
		this.DataContext = new { PieModel, Continents };
	}

	private void InitializeComponent()
	{
		Avalonia.Markup.Xaml.AvaloniaXamlLoader.Load(this);
	}

	public PlotModel PieModel { get; set; }

	public ObservableCollection<ContinentItem> Continents { get; private set; }
}

public class ContinentItem
{
	public string? Name { get; set; }

	public double PopulationInMillions { get; set; }

	public bool IsExploded { get; set; }
}
