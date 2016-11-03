using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using VirtoCommerce.Mobile.iOS.UI.ProductDetail.RowsData;

namespace VirtoCommerce.Mobile.iOS.UI.ProductDetail
{
    public class ProductDetailTableSource : UITableViewSource
    {
        public List<RowInfo> CellsData { set; get; }
        public ProductDetailTableSource(List<RowInfo> cells)
        {
            CellsData = cells;
        }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var key = CellsData[indexPath.Row].CellId;
            var cell = tableView.DequeueReusableCell(CellsData[indexPath.Row].CellId, indexPath);
            switch (key)
            {
                case "SliderCell":
                    var sliderCell = cell as SliderCell;
                    if (sliderCell == null)
                    {
                        sliderCell = new SliderCell();
                    }
                    sliderCell.UpdateCell(((RowDataSlider)CellsData[indexPath.Row]).Images);
                    return sliderCell;
                case "InfoCell":
                    var infoCell = cell as InfoCell;
                    if (infoCell == null)
                    {
                        infoCell = new InfoCell();
                    }
                    infoCell.UpdateCell(((RowDataInfo)CellsData[indexPath.Row]));
                    break;
                default:

                    var cellData = CellsData[indexPath.Row];
                    if (cell == null)
                    {
                        cell = new UITableViewCell(UITableViewCellStyle.Default, cellData.CellId);
                    }
                    cell.ContentView.BackgroundColor = UIColor.Yellow;
                    cell.TextLabel.Text = cellData.Text;
                    cell.TextLabel.TextColor = cellData.TextColor;
                    cell.TextLabel.Lines = 0;
                    cell.TextLabel.LineBreakMode = UILineBreakMode.WordWrap;
                    cell.TextLabel.Font = UIFont.FromName("Helvetica Neue", cellData.FontSize);
                    cell.TextLabel.SizeToFit();
                    cellData.Height = cell.TextLabel.Frame.Height;
                    break;
            }

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return CellsData.Count;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return CellsData[indexPath.Row].Height;
        }
    }
}