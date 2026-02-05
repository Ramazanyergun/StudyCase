# LLM Kullanım Dokümantasyonu

> Bu dosyayı case boyunca kullandığınız LLM (ChatGPT, Claude, Copilot vb.) etkileşimlerini belgelemek için kullanın.
> Dürüst ve detaylı dokümantasyon beklenmektedir.

## Özet

| Bilgi | Değer |
|-------|-------|
| Toplam prompt sayısı | X |
| Kullanılan araçlar | ChatGPT Gemini |
| En çok yardım alınan konular | Animation System / Interactable System / PlayerMovement /  |
| Tahmini LLM ile kazanılan süre | 2 |

---

## Prompt 1: Interaction System

**Araç:** [ChatGPT-4 ]
**Tarih/Saat:** 2026-02-05 16:15

**Prompt:**
```
karakterin intereaksiyon yapabildiği bir sistem kurmak istiyorum ve bunu scriptable objectsler ile yapmayı düşünüyorum yardımcı olur musun
```

**Alınan Cevap (Özet):**
```
🧠 Temel Mimari
1️⃣ Interactable (MonoBehaviour – sahnedeki objeler)
2️⃣ InteractionData (ScriptableObject – ne olacağını tanımlar)
3️⃣ PlayerInteraction (raycast + input)

1️⃣ InteractionData (Scriptable Object)

Bu SO “ne yapılacağını” bilir.

using UnityEngine;

public abstract class InteractionData : ScriptableObject
{
    public string interactionText;

    public abstract void Interact(GameObject interactor);
}


2️⃣ Interactable (Sahnedeki Objeler)

Bu script objenin üstünde olur ve hangi SO’yu kullanacağını bilir.

using UnityEngine;

public class Interactable : MonoBehaviour
{
    public InteractionData interactionData;

    public void Interact(GameObject interactor)
    {
        interactionData?.Interact(interactor);
    }
}

3️⃣ PlayerInteraction (Raycast + Input)

Bu script player’da olur.

using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 2f;
    public LayerMask interactionLayer;

    private Interactable currentInteractable;

    void Update()
    {
        CheckForInteractable();

        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact(gameObject);
        }
    }

    void CheckForInteractable()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance, interactionLayer))
        {
            currentInteractable = hit.collider.GetComponent<Interactable>();
        }
        else
        {
            currentInteractable = null;
        }
    }
}
```

**Nasıl Kullandım:**
- [ ] Direkt kullandım (değişiklik yapmadan)
- [ ] Adapte ettim (değişiklikler yaparak)
- [X] Reddettim (kullanmadım)

**Açıklama:**
> Interaction system  üzerinde bir kez çalıştığım için pek aşina olduğum bir mekanik değildi bu sebeple hem bir örnek senaryo görmek hem de kodun nasıl çalıştığını hatırlamak istedim
> Reddettim çünkü hem aklıma tam yatmadı biraz karışık geldi daha önce yaptığımda bu kadar karışık değildi hem de direkt çalıştıramadım üzerine düşmem gerekiyordu

**Yapılan Değişiklikler (adapte ettiyseniz):**
> [LLM cevabını nasıl değiştirdiğinizi açıklayın]

---

## Prompt 2: Player Movement

**Araç:** [Gemini]
**Tarih/Saat:** 2026-02-05 12:12

**Prompt:**
```
karakter anlamadığım bir şekilde yavaşça yukarı çıkıyor neden olabilir
```

**Alınan Cevap (Özet):**
```
arakterinin yavaşça yukarı doğru yükselmesi (uçması), Unity'de fizik tabanlı hareket yazarken sıkça karşılaşılan bir durumdur. Bunun genellikle üç temel sebebi olur:

1. Rigidbody Yerçekimi (Gravity) Sorunu
Kodunda m_playerRB.linearVelocity = newVelocity; satırında eğer newVelocity.y değerine küçük de olsa pozitif bir değer geliyorsa veya yerçekimi etkisini yanlışlıkla devre dışı bırakıyorsan karakter yükselir.

Çözüm: Rigidbody bileşeninde "Use Gravity" kutusunun işaretli olduğundan emin ol.

Kod Kontrolü: Kodda newVelocity.y = currentYVelocity; satırını yazdığından emin ol. Eğer bu satırı yazmazsan, her karede dikey hızı sıfırlarsın ve en ufak bir zemin sürtünmesi karakteri yukarı fırlatabilir.

2. Kapsül Çarpışması (Capsule Collider) ve Sürtünme
Eğer karakterinin altında bir Capsule Collider varsa ve bu collider yerin içine biraz giriyorsa, Unity'nin fizik motoru objeleri birbirinden ayırmak için yukarı doğru bir güç uygular.

Çözüm: Karakterinin Rigidbody ayarlarından Collision Detection kısmını Continuous yapmayı dene. Ayrıca zeminle olan sürtünmeyi sıfırlamak için bir "Physic Material" oluşturup (Friction: 0) collider'a atayabilirsin.

3. Merdiven/Basamak Etkisi (Step Offset)
Eğer hareket ederken kameranın ileri (forward) vektörünü kullanıyorsan ve kamera hafifçe aşağı bakıyorsa, cam.forward vektörünün y bileşeni negatif olur. Sen bunu targetDir.y = 0 yaparak temizledin ama eğer temizlenmezse karakter yere doğru bir kuvvet uygular ve fizik motoru tepki olarak onu yukarı iter.
```

**Nasıl Kullandım:**
- [ ] Direkt kullandım
- [ ] Adapte ettim
- [X] Reddettim

**Açıklama:**
>3D karakterlerde ilk başlarda hep bu sorunu yaşıyordum karakterin root nesnesine eklediğim componentler özellikle animator, rigidbody ve collider birbiri ile çakışıyor sanırım bu sebeple animator componentini mesh nesnesine ekledim.

---

## Prompt 3: Interaction System


**Araç:** [Gemini]
**Tarih/Saat:** 2026-02-05 17:30

**Prompt:**
```
Karakterimi etraftaki nesneler ile interaksiyona sokmak istiyorum bunun en iyi yolu nedir
```

**Alınan Cevap (Özet):**
```
Unity'de etkileşim (interaction) sistemi kurmanın en profesyonel ve ölçeklenebilir yolu "Interface (Arayüz)" kullanmaktır.

Bu yöntemle karakterin bir kapıyla, sandıkla veya yerden alınacak bir kılıçla etkileşime girerken; karakter koduna her nesne için ayrı ayrı "kapıysa şunu yap, sandıksa bunu yap" demene gerek kalmaz. Karakterin sadece "önümdeki nesne etkileşime uygun mu?" diye sorar.

İşte adım adım en iyi uygulama yolu:

1. Bir Arayüz (Interface) Oluştur
Önce tüm etkileşilebilir nesnelerin ortak dilini tanımlayalım. Buna IInteractable diyelim.

 
2. Etkileşimli Nesneleri Hazırla
Şimdi bu arayüzü kullanan birkaç nesne örneği yapalım.

 
 
3. Karakterin Etkileşimi Algılaması (Raycast)
Karakterin tam önüne bakıp etkileşime geçebileceği bir şey olup olmadığını anlaması için Raycast kullanırız. InputManager içindeki etkileşim tuşuna (örneğin "E" veya "F") basıldığında şu metodu tetikleyebilirsin:
 
Neden Bu Yöntemi Seçmelisin?
Sınırsız Nesne: Yarın oyuna "Bilgisayar", "NPC" veya "Lamba" eklersen, sadece IInteractable arayüzünü scriptine eklersin. Karakter koduna dokunman bile gerekmez.

Temiz Kod: if (hit.tag == "Door") gibi karmaşık ve yavaş çalışan tag kontrollerinden kurtulursun.

Katman Desteği (LayerMask): Raycast yaparken bir LayerMask ekleyerek ışının sadece "Interactable" katmanındaki nesnelere çarpmasını sağlayabilir, performans ve doğruluk artırabilirsin.
```

**Nasıl Kullandım:**
- [ ] Direkt kullandım
- [ ] Adapte ettim
- [X] Reddettim

**Açıklama:**
>Çünkü Interfaceler ile yapmak yerine Scriptable Objects kullanmak istedim.

---

## Genel Değerlendirme

### LLM'in En Çok Yardımcı Olduğu Alanlar
1. Player Input
2. Debugging
3. Camera Follow

### LLM'in Yetersiz Kaldığı Alanlar
1. Interaction System
2. Animasyon çakışmaları ve bozukluğu

### LLM Kullanımı Hakkında Düşüncelerim
> Interaction systemi tam entegre edemesem de çalışma mekaniği aklıma iyice yattı bir sohbeti tek bir mekanik için kullansam belki de entegre edebilirdim. Onun dışında debugging kısmında gayet başarılı.
> İki günde bile bitiremeyebilirdim :)
> Her mekanik için tek bir sohbet ve tek bir LLM modeli kullanmak işleri daha da hızlandırabilir çünkü böyle yapılmadığında modellerin performansı düşüyor.

---

## Notlar

- Her önemli LLM etkileşimini kaydedin
- Copy-paste değil, anlayarak kullandığınızı gösterin
- LLM'in hatalı cevap verdiği durumları da belirtin
- Dürüst olun - LLM kullanımı teşvik edilmektedir

---

*Bu şablon Ludu Arts Unity Intern Case için hazırlanmıştır.*
