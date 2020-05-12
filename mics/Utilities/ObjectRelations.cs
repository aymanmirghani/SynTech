//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Data;
//namespace MICS.Utilities
//{
//    public class ObjectRelations
//    {
//        public ObjectRelations()
//        {
//        }
//        DataTable Relate(DataTable parent, DataTable child, DataColumn parentID, DataColumn childID)
//        {
//            DataTable dt = new DataTable();
//            dt.Columns.Clear();
//            dt.Columns.AddRange(parent.Columns);
//            dt.Columns.AddRange(child.Columns);

//            bool found = false;

//            foreach (DataRow prow in parent.Rows)
//            {
//                foreach (DataRow crow in child.Rows)
//                {
//                    if (prow[parentID.ColumnName] == crow[childID.ColumnName])
//                    {
//                        DataRow dr = new DataRow();
//                        dr.GetChildRows
//                        return dt;
//                    }
//                }
//            }

//        }

//    }
//}
