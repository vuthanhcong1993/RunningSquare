using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyMobile;
using System;

public class PurchaseManager : MonoBehaviour {

	

    private void OnEnable()
    {
        IAPManager.PurchaseCompleted += IAP_PurchaseCompleleted;
        IAPManager.PurchaseFailed+= IAPManager_PurchaseFailed;

    }

    private void OnDisable()
    {
        IAPManager.PurchaseCompleted -= IAP_PurchaseCompleleted;
        IAPManager.PurchaseFailed -= IAPManager_PurchaseFailed;
    }

    private void IAP_PurchaseCompleleted(IAPProduct product)
    {
        Debug.Log(product.Name + "SS");
        if (product.Name== EM_IAPConstants.Product_noads)
        {
            AdsManager.Instance.RemoveAds();
        }
    }


    private void IAPManager_PurchaseFailed(IAPProduct product)
    {
        Debug.Log(product.Name + "ff");
        if (product.Name == EM_IAPConstants.Product_noads)
        {
            return;
        }
    }

    public void Purchase()
    {
            IAPManager.Purchase(EM_IAPConstants.Product_noads);
    }


}
