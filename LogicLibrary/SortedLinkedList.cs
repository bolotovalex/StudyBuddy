using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary
{
    public class SortedQueueDeviation
    {        
        public AreaDeviation? root { get; set; }
        public int ElementsCount = 0;

        public void AddArea(AreaDeviation area)
        {
            AddArea((area.firstCoord.x, area.firstCoord.y), (area.secondCoord.x, area.secondCoord.y),area.deviation);
        }

        public void AddArea((int x1, decimal y1) firstCoord, (int x2, decimal y2) seconCoord, decimal deviation)
        {
            ElementsCount++;
            var newArea = new AreaDeviation(firstCoord, seconCoord, deviation);
            if (root == null)
            {
                this.root = newArea;
            }
            else
            {
                var currArea = root;
                while (true)
                {
                    if (currArea.nextArea != null)
                    {
                        currArea = currArea.nextArea;
                        continue;
                    }

                    currArea.nextArea = newArea;
                    break;
                }
            }
        }


        //public void AddArea((int x1, decimal y1) firstCoord, (int x2, decimal y2) seconCoord, decimal deviation)
        //{
        //    elementsCount++;
        //    var newArea = new AreaDeviation(firstCoord, seconCoord, deviation);

        //    if (root == null)
        //    {
        //        this.root = newArea;
        //    }
        //    else if (newArea.MoreThen(root))
        //    {
        //        newArea.nextArea = root;
        //        root.prevArea = newArea;
        //        root = newArea;
        //    }
        //    else
        //    {
        //        var currArea = root;
        //        while (true)
        //        {
        //            if (currArea.nextArea == null)
        //            {
        //                if (currArea.MoreThen(newArea))
        //                {
        //                    currArea.nextArea = newArea;
        //                    newArea.prevArea = currArea;
        //                    break;
        //                }
        //                else
        //                {
        //                    newArea.nextArea = currArea;
        //                    newArea.prevArea = currArea.prevArea;

        //                    if (currArea.prevArea != null)
        //                        currArea.prevArea.nextArea = newArea;

        //                    currArea.prevArea = newArea;
        //                    break;
        //                }
        //            }
        //            else
        //            {
        //                if (currArea.MoreThen(newArea))
        //                {
        //                    currArea = currArea.nextArea;
        //                    continue;
        //                }
        //                else
        //                {
        //                    newArea.nextArea = currArea;
        //                    newArea.prevArea = currArea.prevArea;

        //                    if (currArea.prevArea != null)
        //                        currArea.prevArea.nextArea = newArea;

        //                    currArea.prevArea = newArea;
        //                    break;
        //                }

        //            }
        //        }
        //    }
        //}

        public AreaDeviation[] GetBigestElements(int count)
        {
            ///<summary></summary>
            //var arr = new AreaDeviation[elementsCount > count ? count : elementsCount];
            var arr = new List<AreaDeviation>();
            var currArea = root;
            for (int i = 0; i < ElementsCount; i++)
            {
                arr.Add(currArea);
                currArea = currArea.nextArea;
                //arr[i++] = currArea;
                //if (currArea.nextArea == null)
                //    break;
                
                //if (i != arr.Length) 
                //    currArea = currArea.nextArea;
                
            }
            return arr.ToArray();
        }

        //TODO нужно реализовать выдачу наименьших n элементов
        //public AreaDeviation[] GetSmalestElements(int count)
        //{
        //    ///<summary></summary>
        //    var arr = new AreaDeviation[elementsCount >= count ? count : elementsCount];
        //    var currArea = root;
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        arr[i] = currArea;
        //        currArea = currArea.nextArea;
        //    }
        //    return arr;
        //}

    }
}
