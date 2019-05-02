using Assets.Scripts.SceneObjects.Obstacles;
using Assets.Scripts.SceneObjects.SceneCamera;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Scene.Level
{
    public class LevelWindow
    {
        [Inject]
        private ICameraFacade m_Camera;

        [Inject]
        private LevelSettings m_LevelSettings;

        [Inject]
        public IObstacleSpawner m_ObstacleSpawner;

        public float Bottom => -ExtentHeight;

        public float Top => Height + m_Camera.Transform.position.y; 

        public float Left => -ExtentWidth; 

        public float Right => ExtentWidth;

        public float ExtentHeight => Mathf.Abs(m_Camera.Transform.position.z) * Mathf.Tan(m_Camera.FieldOfView);

        public float Height => ExtentHeight * 2; 

        public float ExtentWidth => m_Camera.Aspect * Height;

        public float Width => ExtentWidth * 2;


        private float m_CellSize;
        private Vector3 m_CurrentRowPosition;
        private int m_CellQuantityInRow;        
        private int m_InitCellsQuantityInHeight;

        public void Init()
        {
            m_ObstacleSpawner.Init();

            m_CellSize = m_LevelSettings.SpawnCellSize;
            m_CurrentRowPosition = new Vector3(Left, 0, 0);
            m_CellQuantityInRow = Mathf.RoundToInt(Width / m_CellSize);
            m_InitCellsQuantityInHeight = Mathf.RoundToInt(Height / m_CellSize);
            m_Camera.ChangedHeight += SpawnRowIfNeed;
            InitScene();
        }

        private void InitScene()
        {
            for (int i = 0; i < m_InitCellsQuantityInHeight; i++)
            {
                MoveToNextRow();
                SpawnObstacles();
            }
        }

        private void SpawnRowIfNeed()
        {
            if (m_CurrentRowPosition.y - Top < 2 * m_CellSize)
            {
                MoveToNextRow();
                SpawnObstacles();
            }
        }

        private void MoveToNextRow()
        {
            m_CurrentRowPosition.y += m_CellSize;
        }

        private void SpawnObstacles()
        {
            for (int i = 0; i < m_CellQuantityInRow; i++)
            {                
                Vector3 cellPosition = m_CurrentRowPosition;
                cellPosition.x += m_CellSize * i;
                m_ObstacleSpawner.SpawnObstacleInCell(cellPosition);
            }
        }

    }
}
