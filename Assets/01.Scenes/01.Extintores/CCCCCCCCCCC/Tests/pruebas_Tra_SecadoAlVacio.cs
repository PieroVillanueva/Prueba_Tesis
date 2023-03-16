using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class pruebas_Tra_SecadoAlVacio
    {
        
        [UnityTest]
        public IEnumerator pruebaAgarradoObjeto1()
        {
            yield return new WaitForSeconds(1.0f);
            var gameobject = new GameObject();
            var funcionalidad = gameobject.AddComponent<FunObjetoPosInicial>();

            funcionalidad.agarrar();

            Assert.AreEqual(true, funcionalidad.agarrado);
        }

        [UnityTest]
        public IEnumerator pruebaAgarradoObjeto2()
        {
            yield return new WaitForSeconds(1.0f);
            var gameobject = new GameObject();
            var funcionalidad = gameobject.AddComponent<FunObjetoPosInicial>();

            funcionalidad.agarrar();
            yield return new WaitForSeconds(2.0f);
            Assert.AreEqual(true, funcionalidad.agarrado);
        }
        [UnityTest]
        public IEnumerator pruebaAgarradoObjeto3()
        {
            yield return new WaitForSeconds(1.0f);
            var gameobject = new GameObject();
            var funcionalidad = gameobject.AddComponent<FunObjetoPosInicial>();

            funcionalidad.agarrar();
            yield return new WaitForSeconds(3.0f);
            Assert.AreEqual(true, funcionalidad.agarrado);
        }

        [UnityTest]
        public IEnumerator pruebaSoltarObjeto1()
        {
            yield return new WaitForSeconds(1.0f);
            var gameobject = new GameObject();
            var funcionalidad = gameobject.AddComponent<FunObjetoPosInicial>();
            funcionalidad.agarrar();

            funcionalidad.soltar();

            Assert.AreEqual(false, funcionalidad.agarrado);
        }
        [UnityTest]
        public IEnumerator pruebaSoltarObjeto2()
        {
            yield return new WaitForSeconds(1.0f);
            var gameobject = new GameObject();
            var funcionalidad = gameobject.AddComponent<FunObjetoPosInicial>();
            funcionalidad.agarrar();

            funcionalidad.soltar();
            yield return new WaitForSeconds(1.0f);
            Assert.AreEqual(false, funcionalidad.agarrado);
        }
        [UnityTest]
        public IEnumerator pruebaSoltarObjeto3()
        {
            yield return new WaitForSeconds(1.0f);
            var gameobject = new GameObject();
            var funcionalidad = gameobject.AddComponent<FunObjetoPosInicial>();
            funcionalidad.agarrar();

            funcionalidad.soltar();
            yield return new WaitForSeconds(2.0f);
            Assert.AreEqual(false, funcionalidad.agarrado);
        }

        [UnityTest]
        public IEnumerator pruebaObjetoVuelveAsuLugarInicial1()
        {
            var gameobject = new GameObject();
            var funcionalidad = gameobject.AddComponent<FunObjetoPosInicial>();
            funcionalidad.agarrar();
            funcionalidad.soltar();
            funcionalidad.transform.position = new Vector3(10, 10, 10);
            yield return new WaitForSeconds(3.0f);

            Assert.AreEqual(new Vector3(10, 10, 10), funcionalidad.transform.position);
        }
        [UnityTest]
        public IEnumerator pruebaObjetoVuelveAsuLugarInicial2()
        {
            var gameobject = new GameObject();
            var funcionalidad = gameobject.AddComponent<FunObjetoPosInicial>();
            funcionalidad.agarrar();
            funcionalidad.soltar();
            funcionalidad.transform.position = new Vector3(20, 20, 20);
            yield return new WaitForSeconds(4.0f);

            Assert.AreEqual(funcionalidad.posicionInicial, funcionalidad.transform.position);
        }
        [UnityTest]
        public IEnumerator pruebaObjetoVuelveAsuLugarInicial3()
        {
            var gameobject = new GameObject();
            var funcionalidad = gameobject.AddComponent<FunObjetoPosInicial>();
            funcionalidad.agarrar();
            funcionalidad.soltar();
            funcionalidad.transform.position = new Vector3(30, 30, 30);
            yield return new WaitForSeconds(5.0f);

            Assert.AreEqual(funcionalidad.posicionInicial, funcionalidad.transform.position);
        }
    }
}
