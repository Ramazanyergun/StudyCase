# Interaction System - Ramazan YERGÜN

> Ludu Arts Unity Developer Intern Case

## Proje Bilgileri

| Bilgi | Değer |
|-------|-------|
| Unity Versiyonu | 6000.0.5.1f1 |
| Render Pipeline | Built-in / URP  
| Case Süresi | 7-8 |
| Tamamlanma Oranı | %50 |

---

## Kurulum

1. Repository'yi klonlayın:
```bash
git clone https://github.com/Ramazanyergun/StudyCase.git
```

2. Unity Hub'da projeyi açın
3. `Assets/StudyCase/Scenes/TestScene.unity` sahnesini açın
4. Play tuşuna basın

---

## Nasıl Test Edilir

### Kontroller

| Tuş | Aksiyon |
|-----|---------|
| WASD | Hareket |
| Mouse | Bakış yönü | 


### Test Senaryoları

1. **Movement Test:**
   - WASD tuşları ile hareket edin
   - LeftShift tuşu ile sprint atın
   - Mouse ile baskış açınızı değiştirin


---

## Mimari Kararlar

### Interaction System Yapısı

```
[Mimari diyagram veya açıklama]
```

**Neden bu yapıyı seçtim:**
> [Açıklama]

**Alternatifler:**
> [Düşündüğünüz diğer yaklaşımlar ve neden seçmediniz]

**Trade-off'lar:**
> [Bu yaklaşımın avantaj ve dezavantajları]

### Kullanılan Design Patterns

| Pattern | Kullanım Yeri | Neden |
|---------|---------------|-------|
| [Observer] | [Event system] | [Açıklama] |
| [State] | [Door states] | [Açıklama] |
| [vb.] | | |

---

## Ludu Arts Standartlarına Uyum

### C# Coding Conventions

| Kural | Uygulandı | Notlar |
|-------|-----------|--------|
| m_ prefix (private fields) | [] / [x] | |
| s_ prefix (private static) | [x] / [ ] | |
| k_ prefix (private const) | [x] / [ ] | |
| Region kullanımı | [x] / [ ] | |
| Region sırası doğru | [x] / [ ] | |
| XML documentation | [x] / [ ] | |
| Silent bypass yok | [x] / [ ] | |
| Explicit interface impl. | [x] / [ ] | |

### Naming Convention

| Kural | Uygulandı | Örnekler |
|-------|-----------|----------|
| P_ prefix (Prefab) | [] / [x] | P_Door, P_Chest |
| M_ prefix (Material) | [] / [x] | M_Door_Wood |
| T_ prefix (Texture) | [] / [x] | |
| SO isimlendirme | [x] / [ ] | |

### Prefab Kuralları

| Kural | Uygulandı | Notlar |
|-------|-----------|--------|
| Transform (0,0,0) | [] / [x] | |
| Pivot bottom-center | [] / [x] | |
| Collider tercihi | [] / [x] | Box > Capsule > Mesh |
| Hierarchy yapısı | [x] / [ ] | |

### Zorlandığım Noktalar
> Interact system kısmında zorlandım çünkü pek aşina olduğum bir mekanik değildi ve standartlara uymaya çalışmak biraz zamanımı aldı.

---

## Tamamlanan Özellikler

### Zorunlu (Must Have)

- [x] / [ ] Core Interaction System
  - [x] / [ ] IInteractable interface
  - [x] / [ ] InteractionDetector
  - [x] / [ ] Range kontrolü

- [x] / [ ] Interaction Types
  - [x] / [ ] Instant
  - [x] / [ ] Hold
  - [x] / [ ] Toggle

- [x] / [ ] Interactable Objects
  - [x] / [ ] Door (locked/unlocked)
  - [x] / [ ] Key Pickup
  - [x] / [ ] Switch/Lever
  - [x] / [ ] Chest/Container

- [x] / [ ] UI Feedback
  - [x] / [ ] Interaction prompt
  - [x] / [ ] Dynamic text
  - [x] / [ ] Hold progress bar
  - [x] / [ ] Cannot interact feedback

- [x] / [ ] Simple Inventory
  - [x] / [ ] Key toplama
  - [x] / [ ] UI listesi

### Bonus (Nice to Have)

- [ ] Animation entegrasyonu
- [ ] Sound effects
- [ ] Multiple keys / color-coded
- [ ] Interaction highlight
- [ ] Save/Load states
- [ ] Chained interactions

---

## Bilinen Limitasyonlar

### Tamamlanamayan Özellikler
1. [Interaction System] - [Karakter Hareketi ve animasyonuna aşırı vakit harcadım ve tabi bunun yanında Github ile boşa geçirdiğim birkaç saat var:)]


### Bilinen Bug'lar
1. [Bug açıklaması] - [Reproduce adımları]
2. [Bug]

### İyileştirme Önerileri
1. [Öneri] - [Nasıl daha iyi olabilirdi]
2. [Öneri]

---

## Ekstra Özellikler

Zorunlu gereksinimlerin dışında eklediklerim:

1. **[Özellik Adı]**
   - Açıklama: [Sprint Atma]
   - Neden ekledim: [Eklediğim karakter bir ninjaydı bu sebeple eğilerek yürüme animasyonu kullandım sonra bunun tek başına güzel olmadığını düşünüp birde sprint animasyonu ekledim]

2. **[Özellik Adı]**
   - ...

---

## Dosya Yapısı

```
Assets/
├── StudyCase/
│   ├── Scripts/
│   │   ├── Runtime/
│   │   │   ├── Core/
│   │   │   │   ├── IInteractable.cs
│   │   │   │   └── ...
│   │   │   ├── Interactables/
│   │   │   │   ├── Door.cs
│   │   │   │   └── ...
│   │   │   ├── Player/
│   │   │   │   └── ...
│   │   │   └── UI/
│   │   │       └── ...
│   │   └── Editor/
│   ├── ScriptableObjects/
│   ├── Prefabs/
│   ├── Materials/
|   ├── Characters
│   └── Scenes/
│       └── TestScene.unity
├── Docs/
│   ├── CSharp_Coding_Conventions.md
│   ├── Naming_Convention_Kilavuzu.md
│   └── Prefab_Asset_Kurallari.md
├── README.md
├── PROMPTS.md
└── .gitignore
```

---

## İletişim

| Bilgi | Değer |
|-------|-------|
| Ad Soyad | Ramazan YERGÜN |
| E-posta | yergunr@gmail.com |
| LinkedIn | https://www.linkedin.com/in/ramazanyergun/ |
| GitHub | https://github.com/Ramazanyergun/ |

---

*Bu proje Ludu Arts Unity Developer Intern Case için hazırlanmıştır.*
