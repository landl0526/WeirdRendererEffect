using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App6
{
    public class MyViewModel
    {

        List<Item> listItems;
        public List<Item> ListItems
        {
            set
            {
                listItems = value;
            }
            get
            {
                return listItems;
            }
        }
    }

    public class Item
    {
        public string ItemName { set; get; }

        public string DateTimeSet { set; get; }

        Command<object> playOrPauseButtonPressed;
        public Command<object> PlayOrPauseButtonPressed
        {
            set
            {
                playOrPauseButtonPressed = value;
            }
            get
            {
                return playOrPauseButtonPressed;
            }
        }

        Command deleteSingleTask;
        public Command DeleteSingleTask
        {
            set
            {
                deleteSingleTask = value;
            }
            get
            {
                return deleteSingleTask;
            }
        }

        public Item()
        {
            PlayOrPauseButtonPressed = new Command<object>((obj) =>
            {

            });

            DeleteSingleTask = new Command(() =>
            {

            });
        }
    }
}
