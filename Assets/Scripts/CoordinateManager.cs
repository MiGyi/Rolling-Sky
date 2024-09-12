using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateManager
{
    private const float offsetX = 0.5f;
    private const float offsetZ = 0.5f;

    public static Vector3 GetWorldPositionFromTile(int row, int col)
    {
        float dx = ( row * 1.0f + offsetX ) * ConstantValue.TILE_WIDTH;
        float dz = ( col * 1.0f + offsetZ ) * ConstantValue.TILE_HEIGHT;

        return new Vector3(dx, 0, dz);
    }

    public static Vector3 GetWorldPositionFromTile(Vector2 tile)
    {
        return GetWorldPositionFromTile((int)tile.x, (int)tile.y);
    }

    public static Vector2 GetTileFromWorldPosition(Vector3 worldPosition)
    {
        int row = Mathf.FloorToInt(worldPosition.x / ConstantValue.TILE_WIDTH);
        int col = Mathf.FloorToInt(worldPosition.z / ConstantValue.TILE_HEIGHT);

        return new Vector2(row, col);
    }
}
