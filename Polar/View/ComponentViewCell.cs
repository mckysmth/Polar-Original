﻿using System;
using System.Collections.Generic;
using Polar.Model;
using Xamarin.Forms;

namespace Polar.View
{
    public class ComponentViewCell : ViewCell
    {


        public StackLayout MainLayout { get; set; }

        bool isVisible;

        public ComponentViewCell()
        {
            MainLayout = new StackLayout();
            isVisible = false;

        }

        protected override void OnBindingContextChanged()
        {

            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                Piece piece = (Piece)BindingContext;

                Label pieceName = new Label
                {
                    Text = piece.PieceName
                };

                Label projectName = new Label
                {
                    Text = piece.getProject().ProjectName
                };

                MainLayout.Children.Add(pieceName);
                MainLayout.Children.Add(projectName);

                Button button = new Button
                {
                    Text = "V"
                };
                button.Clicked += Button_Clicked;

                MainLayout.Children.Add(button);

                StackLayout taskLayout = new StackLayout();

                foreach (var task in piece.Tasks)
                {
                    Label taskName = new Label
                    {
                        Text = task.TaskName
                    };

                    //taskName.BindingContext = task;

                    taskLayout.Children.Add(taskName);
                }

                taskLayout.IsVisible = isVisible;

                MainLayout.Children.Add(taskLayout);


                View = MainLayout;


            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.ForceUpdateSize();

            Button button = (Button)sender;

            StackLayout stackLayout = (StackLayout)button.Parent;
            if (stackLayout.Children[stackLayout.Children.Count - 1].IsVisible)
            {
                stackLayout.Children[stackLayout.Children.Count - 1].IsVisible = false;
                button.Rotation = 0;
            }
            else
            {
                stackLayout.Children[stackLayout.Children.Count - 1].IsVisible = true;
                button.Rotation = -90;
            }



        }




    }
}
