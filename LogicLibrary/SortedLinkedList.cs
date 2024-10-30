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
        private int elementsCount = 0;

        public void AddArea(AreaDeviation area)
        {
            AddArea((area.intervalX.startX, area.intervalX.endX), (area.intervalY.startY, area.intervalY.endY),area.deviation);
        }
        public void AddArea((int startX, int endX) intervalX, (decimal startY, decimal endY) YCoords, decimal deviation)
        {
            elementsCount++;
            var newArea = new AreaDeviation(intervalX, YCoords, deviation);
            
            if (root == null)
            {
                this.root = newArea;
            }
            else if (newArea.MoreThen(root))
            {
                newArea.nextArea = root;
                root.prevArea = newArea;
                root = newArea;
            }
            else
            {
                var currArea = root;
                while (true)
                {
                    if (currArea.nextArea == null)
                    {
                        if (currArea.MoreThen(newArea))
                            {
                            currArea.nextArea = newArea;
                            newArea.prevArea = currArea;
                            break;
                            }
                        else
                        {
                            newArea.nextArea = currArea;
                            newArea.prevArea = currArea.prevArea;
                            
                            if (currArea.prevArea != null)
                                currArea.prevArea.nextArea = newArea;
                            
                            currArea.prevArea = newArea;
                            break;
                        }
                    }
                    else
                    {
                        if (currArea.MoreThen(newArea))
                        {
                            currArea = currArea.nextArea;
                            continue;
                        }
                        else
                        {
                            newArea.nextArea = currArea;
                            newArea.prevArea = currArea.prevArea;
                            
                            if (currArea.prevArea != null)
                                currArea.prevArea.nextArea = newArea;
                            
                            currArea.prevArea = newArea;
                            break;
                        }

                    }
                }
                if (currArea.prevArea == null)
                {
                    Console.WriteLine(currArea.intervalX.startX.ToString());
                }
            }
        }

        public AreaDeviation[] GetBigestElements(int count)
        {
            ///<summary></summary>
            var arr = new AreaDeviation[elementsCount > count ? count : elementsCount];
            var currArea = root;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = currArea;
                currArea = currArea.nextArea;
            }
            return arr;
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
