using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tuttes_graphs;

namespace TuttesGraphsVisualise
{
    public partial class Form1 : Form
    {
        Graph graph;
        const int vertexHalfSize = 3;
        int circleSize;
        (int, int) centerCoords;
        public Form1()
        {
            InitializeComponent();
            Paint += DrawGraph;
            circleSize = (int)(Math.Min( Size.Width, Size.Height ) / 3.0);
            int center = circleSize * 3 / 2;
            centerCoords = (center, center);

            graph = Graph.FromJson( @"../../../graph.json" );
            graph.GRAPH_SIZE = circleSize * 12 / 5;
        }

        public void DrawGraph(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            Pen p = new Pen( Color.Black );
            Brush b = new SolidBrush( Color.Black );
            for ( int i = 0; i < graph.VertexNum; ++i )
            {
                var v = graph.Vertices[ i ];
                g.DrawEllipse( p, v.X - vertexHalfSize, v.Y - vertexHalfSize, 2 * vertexHalfSize, 2 * vertexHalfSize );
                g.FillEllipse( b, v.X - vertexHalfSize, v.Y - vertexHalfSize, 2 * vertexHalfSize, 2 * vertexHalfSize );
                g.DrawString( (i+1).ToString(), new Font( "calibri", 10 ), b, v.X - 10, v.Y );
                foreach ( var n in v.Neighbors )
                {
                    if (graph.Vertices.IndexOf(n) > i )
                        g.DrawLine( p, new Point( v.X, v.Y ), new Point( n.X, n.Y ) );
                }
            }
        }

        private void redrawBtn_Click( object sender, EventArgs e )
        {
            graph.GetCycle( out var cycle );
            if ( cycle is null )
            {
                MessageBox.Show( "Graph is acyclic" );
                return;
            }
            // расположить точки на окружности размером circle_sizе и центром center
            int N = cycle.Count;
            for (int i = 0; i < N; ++i )
            {
                double ro = circleSize;
                double phi = (double) i / N * 2 * Math.PI;
                double x = ro * Math.Cos( phi );
                double y = ro * Math.Sin( phi );

                cycle[ i ].X = (int)x + centerCoords.Item1;
                cycle[ i ].Y = (int)y + centerCoords.Item2;
            }

            foreach (var v in graph.Vertices )
            {
                if ( cycle.Contains( v ) )
                    continue;
                v.X = (int)v.Neighbors.Select( n => n.X ).Average();
                v.Y = (int) v.Neighbors.Select( n => n.Y ).Average();
            }

            this.Invalidate();
        }
    }
}
