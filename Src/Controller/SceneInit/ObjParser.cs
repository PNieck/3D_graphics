using _3D_graphics.Model.Primitives;
using ObjLoader.Loader.Loaders;
using System.Numerics;

namespace _3D_graphics.Controller.SceneInit
{
    public class ObjParser
    {
        public IEnumerable<Mesh> Parse(String filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException();

            Stream data = new FileStream(filePath, FileMode.Open);
            return Parse(data);
        }

        public IEnumerable<Mesh> Parse(Stream data)
        {
            var objLoaderFactory = new ObjLoaderFactory();
            var objLoader = objLoaderFactory.Create();

            LinkedList<Mesh> result = new LinkedList<Mesh>();

            LoadResult loadedData = objLoader.Load(data);

            List<Vector3> coordinates = GetVerticesCoordinates(loadedData);
            List<Vector3> normals = GetVerticesNormals(loadedData);
            
            foreach (var group in loadedData.Groups)
            {
                LinkedList<Triangle> newMesh = new LinkedList<Triangle>();

                foreach (var face in group.Faces)
                {
                    if (face.Count != 3)
                        throw new ArgumentException("Invalid obj file");

                    var faceV0 = face[0];
                    var faceV1 = face[1];
                    var faceV2 = face[2];

                    Vertex v1 = new Vertex(coordinates[faceV0.VertexIndex - 1], normals[faceV0.NormalIndex - 1]);
                    Vertex v2 = new Vertex(coordinates[faceV1.VertexIndex - 1], normals[faceV1.NormalIndex - 1]);
                    Vertex v3 = new Vertex(coordinates[faceV2.VertexIndex - 1], normals[faceV2.NormalIndex - 1]);

                    newMesh.AddLast(new Triangle(v1, v2, v3));
                }

                result.AddLast(new Mesh(newMesh));
            }

            return result;
        }

        private List<Vector3> GetVerticesCoordinates(LoadResult loadedData)
        {
            List<Vector3> coordinates = new List<Vector3>(loadedData.Vertices.Count);

            foreach (var vertex in loadedData.Vertices)
            {
                coordinates.Add(new Vector3(vertex.X, vertex.Y, vertex.Z));
            }

            return coordinates;
        }

        private List<Vector3> GetVerticesNormals(LoadResult loadedData)
        {
            List<Vector3> normals = new List<Vector3>(loadedData.Normals.Count);

            foreach (var normal in loadedData.Normals)
            {
                normals.Add(new Vector3(normal.X, normal.Y, normal.Z));
            }

            return normals;
        }
    }
}
