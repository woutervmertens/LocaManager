using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LocaManager
{
    public class Command : ICommand
    {
        private readonly Action action;

        public Command(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            action();
        }
    }

    public static class ScrollToSelectedBehavior
    {
        public static readonly DependencyProperty SelectedValueProperty = DependencyProperty.RegisterAttached(
            "SelectedValue",
            typeof(object),
            typeof(ScrollToSelectedBehavior),
            new PropertyMetadata(null, OnSelectedValueChange));

        public static void SetSelectedValue(DependencyObject source, object value)
        {
            source.SetValue(SelectedValueProperty, value);
        }

        public static object GetSelectedValue(DependencyObject source)
        {
            return (object)source.GetValue(SelectedValueProperty);
        }

        private static void OnSelectedValueChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var listView = d as ListView;
            listView.ScrollIntoView(e.NewValue);
        }
    }
}
