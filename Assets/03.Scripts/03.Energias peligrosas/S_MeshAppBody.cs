using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MeshAppBody : MonoBehaviour
{
    public S_BodyCollider mesh_LeftHand;
    public S_BodyCollider mesh_RightHand;
    //public S_BodyCollider mesh_Body;
    //public S_BodyCollider mesh_Bots;

    // Start is called before the first frame update
    public void CambiarMeshAPP(S_APPs app)
    {
        Debug.Log($"Se cambia modelo {app.APP}");
        switch(app.APP.ToString())
        {
            case "manos":
                if (mesh_LeftHand == null || mesh_RightHand == null) break;

                mesh_LeftHand.ModelSkinned.skin.material = app.changeToAPP;
                mesh_RightHand.ModelSkinned.skin.material = app.changeToAPP;
                Debug.Log("se completo cambio");
                break;

            /*
            case "cuerpo":
                if (mesh_Body == null) break;

                mesh_Body.ModelSkinned.skin.material = app.changeToAPP;
                break;

            case "piernas":
                if (mesh_Bots == null) break;

                mesh_Bots.ModelSkinned.skin.material = app.changeToAPP;
                break;
            */
        }
    }   
}
