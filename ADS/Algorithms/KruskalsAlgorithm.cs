using System.Collections;
using DeeULib;

namespace ADS.Algorithms;

public class Graph : IEnumerable<Edge>
{
    public List<Edge> Edges { get; private set; } = new List<Edge>();
    public Dictionary<string, int> Vertexes { get; private set; } = new Dictionary<string, int>();
    public IEnumerator<Edge> GetEnumerator() => Edges.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => Edges.GetEnumerator();

    public Graph(List<Edge> edges)
    { 
        Edges = edges;
        
        foreach (var edge in edges)
        {
            if (!Vertexes.ContainsKey(edge.VertexA))
                Vertexes.Add(edge.VertexA, 1);
            else
                Vertexes[edge.VertexA]++;
            
            if (!Vertexes.ContainsKey(edge.VertexB))
                Vertexes.Add(edge.VertexB, 1);
            else
                Vertexes[edge.VertexB]++;
            
        }
    }
    public Graph() => Edges = new List<Edge>();
    
    

    public static Graph KruskalsAlgorithm(Graph source)
    {
        var result = new Graph();
    
        source.Edges.Sort();
        result.Edges.Add(source.Edges.First());
        source.Edges.RemoveAt(0);
        
        foreach (var edge in source)
        {
            // if (result.HalfContains(edge))
            // {
            //     // result.Edges.Add(edge);
            //     // source.Edges.Remove(edge);
            // }
        }

        return result;
    }

    public bool HalfContains(Edge edge)
    {
        var newGraph = Edges.Except(new List<Edge>(){edge});


        if (newGraph.Any(x => x.VertexA == edge.VertexA || x.VertexA == edge.VertexB))
        {
            return !newGraph.Any(x => x.VertexB == edge.VertexA || x.VertexB == edge.VertexA);
        }
        return false;
    }
   
}


public class Edge : IComparable<Edge>
{
    public int EdgeWeight { get; set; }
    public string VertexA { get; set; }
    public string VertexB { get; set; }

    public Edge(string vertexA, string vertexB, int weight)
    {
        VertexA = vertexA;
        VertexB = vertexB;
        EdgeWeight = weight;
    }
    
    public int CompareTo(Edge other) => other == null ? 1 : EdgeWeight.CompareTo(other.EdgeWeight);

    public override string ToString() => $"A: {VertexA}, B: {VertexB}, Weight: {EdgeWeight}";
}