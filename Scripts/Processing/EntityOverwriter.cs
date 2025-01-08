using System;

namespace LDtkDefinitionSync
{
    public class EntityOverwriter
    {
        public LDtkProject Base;
        
        public EntityOverwriter(LDtkProject copyFrom, LDtkProject[] copyTo)
        {
            Base = copyFrom;
            OverwriteAllProjects(copyTo);
        }

        private void OverwriteAllProjects(LDtkProject[] copyTo)
        {
            foreach (LDtkProject json in copyTo)
            {
                OverwriteToProject(json);
            }
        }

        public void OverwriteToProject(LDtkProject project)
        {
            Console.WriteLine("Attempting overwrite entities to project: " + project.Name);

            EntityDefinition[] baseEntities = Base.Json.Defs.Entities;
            EntityDefinition[] entities = project.Json.Defs.Entities;
            

            foreach (EntityDefinition baseDef in baseEntities)
            {
                EntityDefinition def = Array.Find(entities, definition => definition.Identifier == baseDef.Identifier);
                if (def != null)
                {
                    OverwriteEntity(baseDef, def);
                }
                
                
            }
        }

        public void OverwriteEntity(EntityDefinition src, EntityDefinition entity)
        {
            Console.WriteLine("Overwriting entity: " + entity.Identifier);

            entity.AllowOutOfBounds = src.AllowOutOfBounds;
            entity.Color = src.Color;
            entity.Doc = src.Doc;
            entity.ExportToToc = src.ExportToToc;
            entity.FieldDefs = src.FieldDefs;
            entity.FillOpacity = src.FillOpacity;
            entity.Height = src.Height;
            entity.Hollow = src.Hollow;
            entity.Identifier = src.Identifier;
            entity.KeepAspectRatio = src.KeepAspectRatio;
            entity.LimitBehavior = src.LimitBehavior;
            entity.LimitScope = src.LimitScope;
            entity.LineOpacity = src.LineOpacity;
            entity.MaxCount = src.MaxCount;
            entity.MaxHeight = src.MaxHeight;
            entity.MaxWidth = src.MaxWidth;
            entity.MinHeight = src.MinHeight;
            entity.MinWidth = src.MinWidth;
            entity.NineSliceBorders = src.NineSliceBorders;
            entity.PivotX = src.PivotX;
            entity.PivotY = src.PivotY;
            entity.RenderMode = src.RenderMode;
            entity.ResizableX = src.ResizableX;
            entity.ResizableY = src.ResizableY;
            entity.ShowName = src.ShowName;
            entity.Tags = src.Tags;
            entity.TileId = src.TileId;
            entity.TileOpacity = src.TileOpacity;
            entity.TileRect = src.TileRect;
            entity.TileRenderMode = src.TileRenderMode;
            entity.TilesetId = src.TilesetId;
            //entity.Uid = src.Uid; //DONT CHANGE
            entity.UiTileRect = src.UiTileRect;
            entity.Width = src.Width;
        }
        
        public void OverwriteFieldDefinitions(FieldDefinition[] src, FieldDefinition[] fields)
        {
            foreach (FieldDefinition baseDef in src)
            {
                FieldDefinition def = Array.Find(fields, definition => definition.Identifier == baseDef.Identifier);
                if (def != null)
                {
                    //OverwriteFieldDefinition(baseDef, def);
                }
            }
        }
    }
        
}