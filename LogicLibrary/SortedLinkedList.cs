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
            AddArea((area.intervalX.startX, area.intervalX.endX), area.deviation);
        }
        public void AddArea((int startX, int endX) interval, decimal deviation)
        {
            elementsCount++;
            var newArea = new AreaDeviation(interval, deviation);
            
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
                            currArea.prevArea.nextArea = newArea;
                            currArea.prevArea = newArea;
                            break;
                        }

                    }
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
