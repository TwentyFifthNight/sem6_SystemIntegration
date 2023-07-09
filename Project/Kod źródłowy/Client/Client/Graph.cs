using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Client
{
    internal class Graph
    {
        private static int ColorIndex = 0;

        private static Series GetSeries(Color color, AxisType axis = AxisType.Primary)
        {
            var series = new Series
            {
                Color = color,
                IsVisibleInLegend = true,
                ChartType = SeriesChartType.Line,
                YAxisType = axis,
            };
            return series;
        }

        private static readonly HashSet<Color> colors =
            new HashSet<Color>()
            {
                Color.Green,
                Color.Blue,
                Color.Red,
                Color.Magenta,
                Color.Orange,
                Color.DarkViolet,
                Color.Cyan,
                Color.DarkGray,
                Color.Brown,
            };

        private static readonly Dictionary<string, HashSet<string>> mainPollutions =
            new Dictionary<string, HashSet<string>>()
            {
                ["GórnictwoIWydobywanie"] = new HashSet<string>()
                {
                    "PM10",
                    "SO2"
                },
                ["PrzetwórstwoPrzemysłowe"] = new HashSet<string>()
                {
                    "PM25",
                    "C6H6"
                },
                ["Wytwarzanie i zaopatrywanie w energię elektryczną, gaz, parę wodną, gorącą wodę i powietrze do układów klimatyzacyjnych"] = new HashSet<string>()
                {
                    "PM25",
                    "SO2",
                    "NO2",
                    "NOx",
                    "O3"
                }
            };

        public static Dictionary<string, int> FillGraphWithPollutions(string data, Chart graph, string choosenIndustry, int floorRange = 2011, int ceilRange = 2021)
        {
            int floorYearRange = floorRange, ceilYearRange = ceilRange;

            ColorIndex = 0;

            try
            {
                var content = JsonConvert.DeserializeObject<dynamic>(data);

                foreach (var pollution in content)
                {
                    var series = GetSeries(colors.ElementAt(ColorIndex));
                    ColorIndex++;
                    series.Name = pollution.Name;
                    //jeśli aktualnie wybrany przemysł jest dużym źródłem danego zanieczyszczenia 
                    if (mainPollutions[choosenIndustry].Contains(pollution.Name))
                        series.BorderWidth = 2;
                    
                    graph.Series.Add(series);
                    foreach (var voivodeship in content[pollution.Name])
                    {
                        //zakres lat
                        floorYearRange = content["SO2"][voivodeship.Name].First["year"].ToObject<int>();
                        ceilYearRange = content["SO2"][voivodeship.Name].Last["year"].ToObject<int>();
                        foreach (var value in content[pollution.Name][voivodeship.Name])
                        {
                            //tylko wybrane lata
                            if (ceilRange < value["year"].ToObject<int>() || value["year"].ToObject<int>() < floorRange)
                                continue;
                            series.Points.AddXY(value["year"].ToObject<int>(), value["mean"].ToObject<double>());
                        }
                    }
                }

                Dictionary<string, int> output = new Dictionary<string, int>
                {
                    ["floorYearRange"] = floorYearRange,
                    ["ceilYearRange"] = ceilYearRange
                };
                return output;
            }catch (Exception)
            {
                return null;
            }
        }

        public static void FillGraphWithIndustry(string data, string industry, Chart graph, int floorRange = 2011, int ceilRange = 2021)
        {
            var industries = JsonConvert.DeserializeObject<dynamic>(data);
            var series = GetSeries(colors.ElementAt(8), AxisType.Secondary);
            series.BorderWidth = 3;
            series.MarkerStyle = MarkerStyle.Diamond;
            series.MarkerBorderColor = Color.Black;
            series.MarkerBorderWidth = 3;


            graph.Series.Add(series);
            foreach (var voivodeship in industries[industry])
            {
                series.Name = industry + "[" + voivodeship.Name + "]";
                foreach (var value in industries[industry][voivodeship.Name])
                {
                    if (value.year.ToObject<int>() < floorRange || value.year.ToObject<int>() > ceilRange)
                        continue;
                    series.Points.AddXY(value.year.ToObject<int>(), value.value.ToObject<long>());
                }
            }
            graph.ChartAreas[0].RecalculateAxesScale();
        }
    }
}
