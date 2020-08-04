using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Ink;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Windows.Media;
using GalaSoft;
using CommonServiceLocator;


namespace Painter
{
    class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

    class ViewModel:ViewModelBase
    {
        public ViewModel()
        {
            PropertyChanged += (o, e) =>
            {
                if (e.PropertyName == "CurrentColor")
                {
                    DrawingAttributes.Color = ((ViewModel)o).CurrentColor;
                    OnPropertyChanged("DrawingAttributes");
                }
            };
        }

        InkCanvas InkCanvas;

        Color currentColor = new Color();

        DrawingAttributes drawingAttributes = new DrawingAttributes();
        InkCanvasEditingMode editingMode = InkCanvasEditingMode.Ink;
        StrokeCollection strokes = new StrokeCollection();

        Point firstPos;

        Point lastPos;


        public StrokeCollection Strokes
        {
            get
            {
                return strokes;
            }
            set
            {
                strokes = value;
                OnPropertyChanged();
            }
        }

        public DrawingAttributes DrawingAttributes
        {
            get
            {
                return drawingAttributes;
            }
            set
            {
                drawingAttributes = value;
                OnPropertyChanged();
            }
        }

        public Color CurrentColor
        {
            get
            {
                return currentColor;
            }
            set
            {
                currentColor = value;
                OnPropertyChanged();
            }
        }

        public InkCanvasEditingMode EditingMode
        {
            get
            {
                return editingMode;
            }
            set
            {
                editingMode = value;
                OnPropertyChanged();
            }
        }

        public ICommand SomeC
        {
            get
            {
            
                return new RelayCommand<Object>(new Action<Object>(ChangeMode));
            }
        }
        public void ChangeMode(Object o)
        {
            ComboBoxItem cb = (ComboBoxItem)o;
            switch (cb.Tag.ToString())
            {
                case "Selection":
                    EditingMode = InkCanvasEditingMode.Select;
                    break;
                case "Ink":
                    EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "EraseByPoint":
                    EditingMode = InkCanvasEditingMode.EraseByPoint;
                    break;
                case "EraseByStroke":
                    EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
            }
        }
    }
}
