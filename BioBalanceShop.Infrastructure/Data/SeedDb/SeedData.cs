using BioBalanceShop.Infrastructure.Data.Enumerations;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using static BioBalanceShop.Infrastructure.Constants.CustomClaims;

public class SeedData
{
    public Country Bulgaria { get; set; }

    public Country UnitedKingdom { get; set; }

    public Country UnitedStates { get; set; }

    public Country Germany { get; set; }

    public Country Spain { get; set; }


    public Currency BgnCurrency { get; set; }

    public Currency EurCurrency { get; set; }

    public Currency UsdCurrency { get; set; }

    public Currency GbpCurrency { get; set; }


    public Shop BioBalanceShop { get; set; }


    public CustomerAddress AdminUserAddress { get; set; }

    public CustomerAddress IvanIvanovAddress { get; set; }

    public IdentityUserClaim<string> AdminUserClaim { get; set; }

    public IdentityUserClaim<string> CustomerUserClaim { get; set; }

    public ApplicationUser AdminUser { get; set; }

    public ApplicationUser CustomerUser { get; set; }

    public Customer IvanIvanovCustomer { get; set; }


    public Category OrganicProducts { get; set; }

    public Category Superfoods { get; set; }

    public Category MuscleMass { get; set; }

    public Category ImmunitySupport { get; set; }

    public Category DietFoods { get; set; }


    public Product GreenNourishComplete { get; set; }

    public Product MaxNourish { get; set; }

    public Product AcaiImmunoDefence { get; set; }

    public Product AppleCiderVinegarComplex { get; set; }

    public Product WheyNourishChocolateFlavour { get; set; }

    public Product PeaNourish { get; set; }

    public Product ProBioMax { get; set; }

    public Product NaturaC { get; set; }

    public Product MealTimeVanillaFlavour { get; set; }

    public Product FibreAndFull { get; set; }


    public Payment IvanIvanovPayment { get; set; }

    public OrderRecipient IvanIvanovOrderRecipient { get; set; }

    public OrderAddress IvanIvanovOrderAddress { get; set; }

    public Order IvanIvanovOrder { get; set; }

    public OrderItem GreenNourishCompleteOrderItem { get; set; }

    public OrderItem AppleCiderVinegarComplexOrderItem { get; set; }


    public SeedData()
    {
        SeedCountries();
        SeedCurrencies();
        SeedShop();
        SeedCustomerAddresses();
        SeedUsers();
        SeedCustomers();
        SeedCategories();
        SeedProducts();
        SeedPayments();
        SeedOrderRecipients();
        SeedOrderAddresses();
        SeedOrders();
        SeedOrderItems();
    }

    private void SeedCountries()
    {
        Bulgaria = new Country()
        {
            Id = 1,
            Name = "Bulgaria",
            Code = "BG"
        };

        UnitedKingdom = new Country()
        {
            Id = 2,
            Name = "United Kingdom",
            Code = "GB"
        };

        UnitedStates = new Country()
        {
            Id = 3,
            Name = "United States",
            Code = "US"
        };

        Germany = new Country()
        {
            Id = 4,
            Name = "Germany",
            Code = "DE"
        };

        Spain = new Country()
        {
            Id = 5,
            Name = "Spain",
            Code = "ES"
        };
    }
    private void SeedCurrencies()
    {
        BgnCurrency = new Currency()
        {
            Id = 1,
            Code = "BGN",
            Symbol = "лв.",
            IsSymbolPrefix = false
        };

        EurCurrency = new Currency()
        {
            Id = 2,
            Code = "EUR",
            Symbol = "€",
            IsSymbolPrefix = false
        };

        UsdCurrency = new Currency()
        {
            Id = 3,
            Code = "USD",
            Symbol = "$",
            IsSymbolPrefix = true
        };

        GbpCurrency = new Currency()
        {
            Id = 4,
            Code = "GBP",
            Symbol = "£",
            IsSymbolPrefix = true
        };
    }

    private void SeedShop()
    {
        BioBalanceShop = new Shop()
        {
            Id = 1,
            CurrencyId = 2
        };
    }

    private void SeedCustomerAddresses()
    {
        IvanIvanovAddress = new CustomerAddress()
        {
            Id = 1,
            Street = "Tsarigradsko shose 45",
            PostCode = "1000",
            City = "Sofia",
            CountryId = 1
        };
    }

    private void SeedUsers()
    {
        var hasher = new PasswordHasher<ApplicationUser>();

        AdminUser = new ApplicationUser
        {
            Id = "02c32793-47c7-4f3b-9487-d91c2a0e4345",
            UserName = "admin@mail.com",
            NormalizedUserName = "ADMIN@MAIL.COM",
            Email = "admin@mail.com",
            NormalizedEmail = "ADMIN@MAIL.COM",
            EmailConfirmed = true,
            FirstName = "Admin",
            LastName = "User",
            CreatedDate = DateTime.Now
        };

        AdminUserClaim = new IdentityUserClaim<string>()
        {
            Id = 1,
            ClaimType = UserFullNameClaim,
            ClaimValue = "Admin User",
            UserId = "02c32793-47c7-4f3b-9487-d91c2a0e4345"
        };

        AdminUser.PasswordHash =
                 hasher.HashPassword(AdminUser, "AdminPassword123!");

        CustomerUser = new ApplicationUser
        {
            Id = "c4f1530f-2727-4bc8-9de3-075fc7420586",
            UserName = "customer@mail.com",
            NormalizedUserName = "CUSTOMER@MAIL.COM",
            Email = "customer@mail.com",
            NormalizedEmail = "CUSTOMER@MAIL.COM",
            EmailConfirmed = true,
            FirstName = "Ivan",
            LastName = "Ivanov",
            CreatedDate = DateTime.Now
        };

        CustomerUserClaim = new IdentityUserClaim<string>()
        {
            Id = 2,
            ClaimType = UserFullNameClaim,
            ClaimValue = "Ivan Ivanov",
            UserId = "c4f1530f-2727-4bc8-9de3-075fc7420586"
        };

        CustomerUser.PasswordHash =
                 hasher.HashPassword(CustomerUser, "CustomerPassword123!");
    }

    private void SeedCustomers()
    {
        IvanIvanovCustomer = new Customer()
        {
            Id = 1,
            UserId = "c4f1530f-2727-4bc8-9de3-075fc7420586",
            AddressId = 1
        };
    }


    private void SeedCategories()
    {
        OrganicProducts = new Category()
        {
            Id = 1,
            Name = "Organic products"
        };

        Superfoods = new Category()
        {
            Id = 2,
            Name = "Super foods"
        };

        MuscleMass = new Category()
        {
            Id = 3,
            Name = "MuscleMass"
        };

        ImmunitySupport = new Category()
        {
            Id = 4,
            Name = "Immunity Support"
        };

        DietFoods = new Category()
        {
            Id = 5,
            Name = "DietFoods"
        };
    }

    private void SeedProducts()
    {
        GreenNourishComplete = new Product()
        {
            Id = 1,
            Title = "Green Nourish Complete",
            Subtitle = "Certified organic GreeNourish Complete is no ordinary green shake.",
            ProductCode = "SN105",
            Description = "This high-fibre organic foods blend contains over 35 food ingredients (including green foods, vegetables, fruits, berries, herbs, mushrooms and seeds) PLUS bio-active enzymes in a single serving (see below). Organic vegan nutrition made easy, with naturally high food form vitamin C content (for immune system support), as well as plant protein.\r\n\r\nAll of the organic foods in this blend are Soil Association certified and the ingredients come in concentrated powder form. A great all-round supplement to support immunity, digestion (bulk) and optimal nutrition.\r\n\r\nAs well as providing phyto-nutrients (such as chlorophyll), per 100g it provides 9.1g of plant protein, 59g of carbohydrate (with just 12.5g sugars) and 17.1g of fibre (making it a high-fibre food).\r\n\r\nSuitable for vegetarians and vegans.",
            Ingredients = "Product ingredients (dried, powdered): Pre-Sprouted Activated BARLEY, Lucuma Fruit, Linseed (Flaxseed), WHEAT GRASS, Quinoa, BARLEY Grass, Apple, Acai Berry, Baobab Fruit Pulp, Seagreens® Kelp (Ascophyllum Nodosum), Spirulina, Turmeric, Alfalfa, Carrot, Bilberry Fruit, Spinach Leaf, BARLEY Grass Juice, WHEAT GRASS Juice, Beet, Acerola Cherry Extract, Chlorella (Broken Cell Wall), Nettle, Tomato, Bilberry Extract, Blueberry, Cranberry, Green Cabbage, Kale, Parsley, Kale Sprout, Broccoli Sprout, Reishi Mushroom, Cordyceps Mushroom, Shiitake Mushroom, Cauliflower Sprout, Maitake Mushroom, Enzyme Blend* (protease*, amylase*, bromelain*, cellulase*, lactase*, papain*, lipase*). * = Non organic ingredient",
            ImageUrl = "https://www.dropshipwebhosting.co.uk/image/data/product/main/SN105_front.png",
            Quantity = 100,
            Price = 12.00M,
            CategoryId = 1,
            CreatedDate = DateTime.Now,
            CreatedById = "02c32793-47c7-4f3b-9487-d91c2a0e4345",
            ShopId = 1
        };

        MaxNourish = new Product()
        {
            Id = 2,
            Title = "MaxNourish",
            Subtitle = "Organic fruit, vegetable and herbal blend (in capsules)",
            ProductCode = "MSFO",
            Description = "MaxNourish is a 100% organic (Soil Association and EU organic certified) food supplement, with over 35 nutritious fruits, vegetables, sprouts, seeds and herbals PLUS bio-active enzymes (see below).\r\n\r\nWith some of the most nutrient-dense foods that Nature has to offer, it is an all-round multi-nutrient blend in easy-to-take capsules - no poorly-absorbed synthetic vitamins and minerals.\r\n\r\nQuickly and easily access organic and vegan nutrition on a daily basis with just this one product.",
            Ingredients = "Product ingredients (dried, powdered): Capsule Shell: Hydroxypropyl Methylcellulose (HPMC)*, Pre-Sprouted Activated BARLEY Powder (Hordeum vulgare), Lucuma Fruit Powder (Pouteria lucuma), Linseed (Flaxseed) Powder (Linum usitatissimum), WHEAT GRASS Powder (Triticum aestivum), Quinoa Powder (Chenopodium quinoa), BARLEY Grass Powder (Hordeum vulgare), Acai Berry Powder (Euterpe oleracea), Baobab Pulp Powder (Adansonia digitata), Seagreens® Kelp Powder (Ascophyllum Nodosum), Spirulina Powder (Arthrospira platensis), Turmeric Powder (Curcuma longa), Apple Powder (Malus Sylvestris), Alfalfa Powder (Medicago sativa), Carrot Powder (Daucus carota), Bilberry Fruit Powder (Vaccinium myrtillus), Spinach Leaf Powder (Spinacia oleracea), BARLEY Grass Juice Powder (Hordeum vulgare), WHEAT GRASS Juice Powder (Triticum aestivum), Beetroot Powder (Beta vulgaris), Acerola Cherry Extract (Malphigia glabra), Chlorella vulgaris (Broken Cell Wall) Powder, Nettle Leaf Powder (Urtica dioica), Tomato Powder (Lycopersicum esculentum), Bilberry Extract (Vaccinium myrtillus), Blueberry Powder (Vaccinium sp.), Cranberry Powder (Vaccinium macrocarpon), Green Cabbage Powder (Brassica oleracea), Kale Powder (Brassica oleracea acephala), Parsley Powder (Carum petroselinum), Kale Sprout Powder (Brassica oleracea acephala), Broccoli Sprout Powder (Brassica oleracea italica), Reishi Mushroom Powder (Ganoderma Lucidum), Cordyceps Mushroom Powder (Cordyceps militaris), Shiitake Mushroom Powder (Lentinula edodes), Cauliflower Sprout Powder (Brassica oleracea botrytis), Maitake Mushroom Powder (Grifola frondosa), Enzyme Blend* (protease*, amylase*, bromelain*, cellulase*, lactase*, papain*, lipase*) * = Non organic ingredient.",
            ImageUrl = "https://www.dropshipwebhosting.co.uk/image/data/product/main/MSFO_front.png",
            Quantity = 150,
            Price = 18.00M,
            CategoryId = 1,
            CreatedDate = DateTime.Now,
            CreatedById = "02c32793-47c7-4f3b-9487-d91c2a0e4345",
            ShopId = 1
        };

        AcaiImmunoDefence = new Product()
        {
            Id = 3,
            Title = "Acai Immuno Defence",
            Subtitle = "Acai berry immunity complex",
            ProductCode = "SN099B",
            Description = "Acai Immuno Defence is a high-potency formulation, which combines Brazilian acai berry with a range of other beneficial ingredients, including vitamins, minerals and herbs (such as zinc, vitamin B6, biotin, organic Moringa oleifera, beetroot, resveratrol and more - see below). \r\n\r\nThis superfood combination provides support for immunity, energy, bones, hair, skin, nails and more. It also contains polyphenolic anthocyanin compounds, as well as vitamins, minerals and ellagic acid.\r\n\r\nPopular with slimmers, athletes, diabetics and those looking to support their immunity, general health and well-being.",
            Ingredients = "Product ingredients: Stoneground Brown Rice Flour (Oryza Sativa), Organic Moringa Oleifera Powder, Capsule Shell: Hydroxypropyl Methylcellulose (HPMC), Beetroot (Beta vulgaris) Extract, Acai Berry (Euterpe Oleracea Martius) Extract, Rice Extract (Oryza Sativa), Pomegranate Seed (Punica Granatum) Extract, Resveratrol from Japanese Knotweed (Polygonum Cuspidatum) Extract, Zinc (Zinc Citrate), Vitamin B6 (Pyridoxine Hydrochloride), Grape Seed (Vitis Vinifera) Extract, Vitamin B7 (as Biotin Pure).",
            ImageUrl = "https://www.dropshipwebhosting.co.uk/image/data/product/main/SN099B_front.png",
            Quantity = 220,
            Price = 9.60M,
            CategoryId = 2,
            CreatedDate = DateTime.Now,
            CreatedById = "02c32793-47c7-4f3b-9487-d91c2a0e4345",
            ShopId = 1
        };

        AppleCiderVinegarComplex = new Product()
        {
            Id = 4,
            Title = "Apple Cider Vinegar Complex",
            Subtitle = "Apple cider vinegar powder plus herbs",
            ProductCode = "ACV-120",
            Description = "Apple Cider Vinegar Complex is a herbal weight management and digestive health combination.\r\n\r\nThis food supplement has been formulated with a specialist blend of synergistic herbs and nutrients.\r\n\r\nEach capsule combines 400mg of apple cider vinegar powder with cayenne, ginger root, turmeric, green tea leaf, organic black pepper and chromium.\r\n\r\nChromium is scientifically proven to contribute to normal macronutrient metabolism and to the maintenance of normal blood glucose levels.",
            Ingredients = "Product ingredients: Apple Cider Vinegar Powder (Malus Sylvestris), Stoneground Brown Rice Flour (Oryza Sativa), Capsule Shell: Hydroxypropyl Methylcellulose (HPMC), Rice Concentrate (Oryza Sativa), Rice Extract (Oryza Sativa), Cayenne Pepper Extract (Capsicum Annuum), Ginger Root Extract (Zingiber Officinale), Black Pepper Powder (Piper Nigrum), Turmeric Root Extract (Curcuma Longa), Green Tea Leaf Extract (Camellia Sinensis), Chromium Picolinate.",
            ImageUrl = "https://www.dropshipwebhosting.co.uk/image/data/product/main/ACV-120_front.png",
            Quantity = 180,
            Price = 6.00M,
            CategoryId = 2,
            CreatedDate = DateTime.Now,
            CreatedById = "02c32793-47c7-4f3b-9487-d91c2a0e4345",
            ShopId = 1
        };

        WheyNourishChocolateFlavour = new Product()
        {
            Id = 5,
            Title = "WheyNourish (Chocolate Flavour)",
            Subtitle = "From whey concentrate and isolate",
            ProductCode = "WPP600C",
            Description = "A premium quality chocolate-flavoured whey protein powder, derived from a blend of concentrate and isolate.\r\n\r\nProviding 22g of protein and just 1.6g of fat per 30g serving, this formula contains only the highest grade hormone-free milk, sourced from EU and British cows - no GMOs, artificial colours, flavours, sweeteners or added sugar (stevia is used).\r\n\r\nAs well as providing an excellent nutritional (and amino acid) profile, we have ensured that using WheyNourish is a tasty, hassle-free experience. It can be used before or after exercise, or at any time of day as a protein-rich, muscle building and appetite curbing snack.",
            Ingredients = "Product ingredients: Whey Protein Concentrate (MILK); Whey Protein Isolate (MILK, SOY lecithin); Cocoa (Theobroma cacao) Powder; Flavouring; Stabiliser (Xanthan Gum); Sweetener: Stevia Leaf Extract (Steviol glycosides).",
            ImageUrl = "https://www.dropshipwebhosting.co.uk/image/data/product/main/WPP600C_front.png",
            Quantity = 300,
            Price = 21.60M,
            CategoryId = 3,
            CreatedDate = DateTime.Now,
            CreatedById = "02c32793-47c7-4f3b-9487-d91c2a0e4345",
            ShopId = 1
        };

        PeaNourish = new Product()
        {
            Id = 6,
            Title = "PeaNourish",
            Subtitle = "High quality protein PLUS phytonutrients",
            ProductCode = "PP500",
            Description = "PeaNourish is a high quality pea protein powder (from snap peas), blended with a range of other foods and herbs for added nutritional value - chicory root, green tea leaf, dandelion root, spirulina and acai berry (see below).\r\n\r\nThis green protein shake mix contains a concentrated level of pea protein, from the 6% found in fresh peas up to around 80%, and is therefore high in protein (over 18g per serving). It is also low in carbohydrates, high in fibre, easily digestible (no bloating), hypo-allergenic and suitable for vegetarians and vegans.\r\n\r\nPea protein is a natural vegetable-source protein, which offers an excellent amino acid profile. It is also valued for its high digestibility (90-95%), low potential for allergic responses and reasonable price. It is particularly popular because it has a sweet taste and a texture which mixes well in liquid solutions.\r\n\r\nUnlike many other pea protein powders on the market, PeaNourish contains no hexane, toxic chemicals or added 'nasties', which are often used during the pea protein extraction process. Our pea protein is extracted using only water, pressure and then flocculation.",
            Ingredients = "Product ingredients: Pea Protein (Pisum sativum) Isolate, Fibre (Chicory Root (Cichorium intybus) Extract), Green Tea Leaf (Camellia Sinensis) Extract, Dandelion Root (Taraxacum officinale) Powder, Spirulina Powder (Arthrospira platensis), Acai Berry (Euterpe Oleracae Martius) Extract, Stabiliser (Xanthan Gum), Sweetener: Stevia Leaf Extract (Steviol glycosides).",
            ImageUrl = "https://www.dropshipwebhosting.co.uk/image/data/product/main/PP500_front.png",
            Quantity = 98,
            Price = 21.00M,
            CategoryId = 3,
            CreatedDate = DateTime.Now,
            CreatedById = "02c32793-47c7-4f3b-9487-d91c2a0e4345",
            ShopId = 1
        };

        ProBioMax = new Product()
        {
            Id = 7,
            Title = "ProBio MAX",
            Subtitle = "A practitioner-strength, multi-strain live culture combination",
            ProductCode = "PBMAX30",
            Description = "ProBio MAX is a vegan, multi-strain combination of 8 live cultures, providing 20 billion viable organisms per capsule (see below).\r\n\r\nWith no added dairy, sugars, artificial flavourings or colourings, this food supplement provides an alternative to sugary yoghurts and yoghurt drinks containing live cultures. In fact, it provides the equivalent of 40 tubs of probiotic yoghurt, but without the dairy, sugar, fat and calories.\r\n\r\nMicro-encapsulated for acid resistance, this live bacteria biotic has been specifically formulated for natural health practitioners who treat digestive and intestinal disorders. It is ideal for use following antibiotics, travelling abroad and colonic hydrotherapy treatment.",
            Ingredients = "Product ingredients: Capsule Shell: Hydroxypropyl Methylcellulose (HMPC); Brown Rice Flour (Oryza Sativa); Bio-Live Bacteria Blend: Lactobacillus rhamnosus, Lactobacillus casei, Lactobacillus acidophillus, Bifidobacterium infantis, Streptococcus thermophilus, Bifdobacterium breve, Bifidobacterium longum, Lactobacillus bulgaricus; Rice Extract (Oryza Sativa).",
            ImageUrl = "https://www.dropshipwebhosting.co.uk/image/data/product/main/PBMAX30_front.png",
            Quantity = 54,
            Price = 15.00M,
            CategoryId = 4,
            CreatedDate = DateTime.Now,
            CreatedById = "02c32793-47c7-4f3b-9487-d91c2a0e4345",
            ShopId = 1
        };

        NaturaC = new Product()
        {
            Id = 8,
            Title = "NaturaC",
            Subtitle = "Food form vitamin C",
            ProductCode = "SS360",
            Description = "NaturaC is a combination food state vitamin C supplement, derived from some of nature’s richest sources of this important vitamin: Acerola cherry, rosehip, blackcurrant, parsley leaf and elderberry.\r\n\r\nThe natural food ingredients included in this supplement are more easily recognised by the body, facilitating absorption and utilisation - no artificial vitamin C (ascorbic acid). As such, the vitamin C is retained for longer; not rapidly eliminated.\r\n\r\nThis food supplement offers ideal support for: the immune system, collagen formation, blood vessels, bones, cartilage, gums, skin, teeth, energy-yielding metabolism, the nervous system, the protection of cells from oxidative stress, the reduction of tiredness and fatigue, the regeneration of the reduced form of vitamin E and iron absorption.",
            Ingredients = "Product ingredients: Acerola Cherry Extract ((Malphigia glabra) (25% Vitamin C)), Capsule Shell: Hydroxypropyl Methylcellulose (HPMC), Anti-caking Agent: Microcrystalline Cellulose, Parsley Leaf Powder (Petroselinum sativum), Blackcurrant Extract (Ribes Nigrum L.), Rice Extract (Oryza Sativa), Elderberry Extract (Sambucus Nigra L.), Rosehip Extract (Rosa Canina).",
            ImageUrl = "https://www.dropshipwebhosting.co.uk/image/data/product/main/SS360_front.png",
            Quantity = 112,
            Price = 8.40M,
            CategoryId = 4,
            CreatedDate = DateTime.Now,
            CreatedById = "02c32793-47c7-4f3b-9487-d91c2a0e4345",
            ShopId = 1
        };

        MealTimeVanillaFlavour = new Product()
        {
            Id = 9,
            Title = "MEALtime (Vanilla Flavour)",
            Subtitle = "Dairy and gluten-free meal shake",
            ProductCode = "SN049",
            Description = "MEALtime (Vanilla Flavour) is a dairy-free, gluten-free and vegan meal shake and protein powder (non-GM soya protein isolate) that has been fortified with vitamins and minerals.\r\n\r\nHigh in protein (over 72g per 100g), low in fat (0.0g saturated fat per 100g) and with no artificial sweeteners, this vanilla flavoured daily shake is also high in dietary fibre from chicory root extract.\r\n\r\nTasty and filling, MEALtime (Vanilla Flavour) makes for the ideal in-between meals shake. It can even be used as a tasty, guilt-free dessert - only 87 calories per serving!",
            Ingredients = "Product ingredients: SOY (Glycina Maxima) Protein Isolate (SOY); Fibre (Chicory Root (Cichorium intybus) Extract); Natural Flavour; Maltodextrin; Vitamin and Mineral Blend: ((Potassium Chloride, Magnesium Citrate, Vitamin C (Ascorbic Acid), Ferrous Citrate, Zinc Citrate, Copper Citrate, Vitamin E (DL-Alpha-Tocopheryl Acetate), Vitamin B3 (Niacin), Vitamin A (Acetate), Vitamin B12 (Cyanocobalamin), Vitamin B2 (Riboflavin), Vitamin B6 (Pyridoxine Hydrochloride), Vitamin B1 (Thiamine), Folic Acid (Folacin), Potassium Iodide)); Sweetener: Stevia Leaf Extract (Steviol glycosides).",
            ImageUrl = "https://www.dropshipwebhosting.co.uk/image/data/product/main/SN049_front.png",
            Quantity = 88,
            Price = 10.20M,
            CategoryId = 5,
            CreatedDate = DateTime.Now,
            CreatedById = "02c32793-47c7-4f3b-9487-d91c2a0e4345",
            ShopId = 1
        };

        FibreAndFull = new Product()
        {
            Id = 10,
            Title = "Fibre & Full",
            Subtitle = "High dietary fibre, bulk and weight loss blend",
            ProductCode = "SN040",
            Description = "Fibre & Full is an all-in-one dietary fibre based bowel support and weight loss supplement in a tasty, easy-to-take powder form.\r\n\r\nWith a special combination of psyllium husks, sugar beet fibre, glucommanan, L-Glutamine, prebiotics, bacterial cultures, herbs and stevia leaf extract (see more below), the variety of nutrients and high fibre content of this shake make it ideal for long-term use, as well as part of a cleanse and detox programme or weight management programme.\r\n\r\nSpecifically formulated to contribute to healthy weight loss in the context of an energy-restricted diet, normal blood cholesterol levels, as well as a healthy, varied and balanced diet. Sugar beet fibre, in particular, contributes to an increase in faecal bulk and may have a beneficial physiological effect for people who want to improve or maintain a normal bowel function.",
            Ingredients = "Product ingredients: Psyllium Whole Husks Powder (Plantago ovata); Glucomannan Powder (Amorphophallus Konjac); Sugar Beet Fibre Powder (Beta Vulgaris); L-Glutamine Powder; Inulin Powder (Fructo-oligosaccharides); Fennel Seed Powder (Foeniculum Vulgare); Peppermint Leaf Powder (Mentha Piperita); Ginger Root Powder (Zingiber officinale); Bacteria Blend: Lactobacillus Acidophilus, Bifidobacterium Bifidum; Sweetener: Stevia Leaf Extract (Steviol glycosides).",
            ImageUrl = "https://www.dropshipwebhosting.co.uk/image/data/product/main/SN040_front.png",
            Quantity = 133,
            Price = 9.00M,
            CategoryId = 5,
            CreatedDate = DateTime.Now,
            CreatedById = "02c32793-47c7-4f3b-9487-d91c2a0e4345",
            ShopId = 1
        };
    }

    private void SeedPayments()
    {
        IvanIvanovPayment = new Payment()
        {
            Id = 1,
            PaymentDate = DateTime.Now,
            PaymentAmount = 18.00M,
            PaymentStatus = PaymentStatus.Success
        };
    }

    private void SeedOrderRecipients()
    {
        IvanIvanovOrderRecipient = new OrderRecipient()
        {
            Id = 1,
            FirstName = "Ivan",
            LastName = "Ivanov",
            PhoneNumber = "+359883123456",
            EmailAddress = "customer@mail.com",
        };
    }

    private void SeedOrderAddresses()
    {
        IvanIvanovOrderAddress = new OrderAddress()
        {
            Id = 1,
            Street = "Tsarigradsko shose 45",
            PostCode = "1000",
            City = "Sofia",
            CountryId = 1
        };
    }

    private void SeedOrders()
    {
        IvanIvanovOrder = new Order()
        {
            Id = 1,
            OrderNumber = "PO000000",
            OrderDate = DateTime.Now,
            Status = OrderStatus.Processing,
            Amount = 18.00M,
            ShippingFee = 1.80M,
            TotalAmount = 19.80M,
            CurrencyId = 2,
            CustomerId = 1,
            OrderAddressId = 1,
            PaymentId = 1,
            OrderRecipientId = 1
        };
    }

    private void SeedOrderItems()
    {
        GreenNourishCompleteOrderItem = new OrderItem()
        {
            Id = 1,
            Title = "Green Nourish Complete",
            ImageUrl = "https://www.dropshipwebhosting.co.uk/image/data/product/main/SN105_front.png",
            Quantity = 1,
            Price = 12.00M,
            CurrencyId = 2,
            OrderId = 1
        };

        AppleCiderVinegarComplexOrderItem = new OrderItem()
        {
            Id = 2,
            Title = "Apple Cider Vinegar Complex",
            ImageUrl = "https://www.dropshipwebhosting.co.uk/image/data/product/main/ACV-120_front.png",
            Quantity = 1,
            Price = 6.00M,
            CurrencyId = 2,
            OrderId = 1
        };
    }
}
