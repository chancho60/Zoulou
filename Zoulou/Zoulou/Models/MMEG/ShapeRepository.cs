using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace Zoulou.Models.MMEG {
    public class ShapeRepository : BaseRepository {
        IList<IList<object>> Values = ge.getWorksheet("1-dg6TbHNRoptK96CvXAa3ULlkKC8H_pOHz1QT0unNTo", "Shapes");
        private List<Shape> Shapes = new List<Shape>();

        public List<Shape> getShapes() {
            if(Values != null && Values.Count > 0) {
                foreach(var Row in Values) {
                    Shapes.Add(new Shape { ShapeId = Row[0].ToString(), ShapeName = Row[1].ToString() });
                }
            }

            return Shapes;
        }

        public Shape getShapeById(string Id) {
            if(Values != null && Values.Count > 0) {
                foreach(var Row in Values) {
                    if(Row[0].ToString() == Id) {
                        return new Shape { ShapeId = Row[0].ToString(), ShapeName = Row[1].ToString() };
                    }
                }
            }

            return new Shape();
        }
    }
}