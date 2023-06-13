var words = ["a", "abandon", "ability", "able", "abortion", "about", "above", "abroad", "absence", "absolute", "absolutely", "absorb", "abuse", "academic", "accept", "access", "accident", "accompany", "accomplish", "according", "account", "accurate", "accuse", "achieve", "achievement", "acid", "acknowledge", "acquire", "across", "act", "action", "active", "activist", "activity", "actor", "actress", "actual", "actually", "ad", "adapt", "add", "addition", "additional", "address", "adequate", "adjust", "adjustment", "administration", "administrator", "admire", "admission", "admit", "adolescent", "adopt", "adult", "advance", "advanced", "advantage", "adventure", "advertising", "advice", "advise", "adviser", "advocate", "affair", "affect", "afford", "afraid", "African", "African-American", "after", "afternoon", "again", "against", "age", "agency", "agenda", "agent", "aggressive", "ago", "agree", "agreement", "agricultural", "ah", "ahead", "aid", "aide", "AIDS", "aim", "air", "aircraft", "airline", "airport", "album", "alcohol", "alive", "all", "alliance", "allow", "ally", "almost", "alone", "along", "already", "also", "alter", "alternative", "although", "always", "AM", "amazing", "American", "among", "amount", "analysis", "analyst", "analyze", "ancient", "and", "anger", "angle", "angry", "animal", "anniversary", "announce", "annual", "another", "answer", "anticipate", "anxiety", "any", "anybody", "anymore", "anyone", "anything", "anyway", "anywhere", "apart", "apartment", "apparent", "apparently", "appeal", "appear", "appearance", "apple", "application", "apply", "appoint", "appointment", "appreciate", "approach", "appropriate", "approval", "approve", "approximately", "Arab", "architect", "area", "argue", "argument", "arise", "arm", "armed", "army", "around", "arrange", "arrangement", "arrest", "arrival", "arrive", "art", "article", "artist", "artistic", "as", "Asian", "aside", "ask", "asleep", "aspect", "assault", "assert", "assess", "assessment", "asset", "assign", "assignment", "assist", "assistance", "assistant", "associate", "association", "assume", "assumption", "assure", "at", "athlete", "athletic", "atmosphere", "attach", "attack", "attempt", "attend", "attention", "attitude", "attorney", "attract", "attractive", "attribute", "audience", "author", "authority", "auto", "available", "average", "avoid", "award", "aware", "awareness", "away", "awful", "baby", "back", "background", "bad", "badly", "bag", "bake", "balance", "ball", "ban", "band", "bank", "bar", "barely", "barrel", "barrier", "base", "baseball", "basic", "basically", "basis", "basket", "basketball", "bathroom", "battery", "battle", "be", "beach", "bean", "bear", "beat", "beautiful", "beauty", "because", "become", "bed", "bedroom", "beer", "before", "begin", "beginning", "behavior", "behind"];

var all = [];
var part = [];
for (let i = 0; i < words.length; i++) {
    if (i < 300) {
        part[i] = {value: words[i]};
    }
    all[i] = {value: words[i]};
}

//

var cities = {
    "Austria": [
        {
            value: "Vienna"
        },
        {
            value: "Hallstat"
        },
        {
            value: "Klagenfurt"
        },
        {
            value: "Vilach"
        }
    ],
    "Belgium": [
        {
            value: "Antwerp"
        },
        {
            value: "Leuven"
        },
        {
            value: "Dinant"
        },
        {
            value: "Hasselt"
        }
    ],
    "Bulgaria": [
        {
            value: "Minsk"
        },
        {
            value: "Vitebsk"
        },
        {
            value: "Grodno"
        },
        {
            value: "Brest"
        }
    ],
    "Cyprus": [
        {
            value: "Sofia"
        },
        {
            value: "Plodiv"
        },
        {
            value: "Sozopol"
        },
        {
            value: "Nesebar"
        }
    ],
    "Czech Republic": [
        {
            value: "Mikulov"
        },
        {
            value: "Prague"
        },
        {
            value: "Lednice"
        },
        {
            value: "Oprava"
        }
    ],
    "Denmark": [
        {
            value: "Odense"
        },
        {
            value: "Aalborg"
        },
        {
            value: "Kolding"
        },
        {
            value: "Horsens"
        }
    ],
    "Estonia": [
        {
            value: "Tartu"
        },
        {
            value: "Parnu"
        },
        {
            value: "narva"
        },
        {
            value: "Haapsalu"
        }
    ],
    "Finland": [
        {
            value: "Rovaniemi"
        },
        {
            value: "Pori"
        },
        {
            value: "Porvoo"
        },
        {
            value: "Savonlinna"
        }
    ],
    "France": [
        {
            value: "Lyon"
        },
        {
            value: "Colmar"
        },
        {
            value: "Cannes"
        },
        {
            value: "La Rochelle"
        }
    ],
    "Germany": [
        {
            value: "Wuzburg"
        },
        {
            value: "Tier"
        },
        {
            value: "Fussen"
        },
        {
            value: "Bamberg"
        }
    ],
    "Greece": [
        {
            value: "Minsk"
        },
        {
            value: "Vitebsk"
        },
        {
            value: "Grodno"
        },
        {
            value: "Brest"
        }
    ],
    "Hungary": [
        {
            value: "Chania"
        },
        {
            value: "Oia"
        },
        {
            value: "Corinth"
        },
        {
            value: "Rodhes"
        }
    ],
    "Ireland": [
        {
            value: "Galway"
        },
        {
            value: "Cork"
        },
        {
            value: "Limerick"
        },
        {
            value: "Westport"
        }
    ],
    "Italy": [
        {
            value: "Lucca"
        },
        {
            value: "Pissa"
        },
        {
            value: "Turin"
        },
        {
            value: "Milan"
        }
    ],
    "Latvia": [
        {
            value: "Ventspils"
        },
        {
            value: "Daugavpils"
        },
        {
            value: "Velniera"
        },
        {
            value: "Sigulda"
        }
    ],
    "Lithuania": [
        {
            value: "Taurage"
        },
        {
            value: "Svencionelia"
        },
        {
            value: "Ignalina"
        },
        {
            value: "Visaginas"
        }
    ],
    "Luxembourg": [
        {
            value: "Ettelburck"
        },
        {
            value: "Vianden"
        },
        {
            value: "Wiltz"
        },
        {
            value: "Differdange"
        }
    ],
    "Malta": [
        {
            value: "Mdinga"
        },
        {
            value: "Silema"
        },
        {
            value: "Birgu"
        },
        {
            value: "Rabat"
        }
    ],
    "Netherlands": [
        {
            value: "Best"
        },
        {
            value: "Almere"
        },
        {
            value: "Giethoorn"
        },
        {
            value: "Zandvoort"
        }
    ],
    "Poland": [
        {
            value: "Sopot"
        },
        {
            value: "Wieliczka"
        },
        {
            value: "Gdansk"
        },
        {
            value: "Opole"
        }
    ],
    "Portugal": [
        {
            value: "Sintra"
        },
        {
            value: "Lagos"
        },
        {
            value: "Tavira"
        },
        {
            value: "Faro"
        }
    ],
    "Romania": [
        {
            value: "Bran"
        },
        {
            value: "Turda"
        },
        {
            value: "Busteni"
        },
        {
            value: "Gura"
        }
    ],
    "Slovakia": [
        {
            value: "poprad"
        },
        {
            value: "Bardejov"
        },
        {
            value: "Trnava"
        },
        {
            value: "Nitra"
        }
    ],
    "Slovenia": [
        {
            value: "Bled"
        },
        {
            value: "Maribor"
        },
        {
            value: "Ptuj"
        },
        {
            value: "koper"
        }
    ],
    "Spain": [
        {
            value: "Barcelona"
        },
        {
            value: "Granada"
        },
        {
            value: "Malaga"
        },
        {
            value: "Bilbao"
        }
    ],
    "Sweden": [
        {
            value: "Malmo"
        },
        {
            value: "Visby"
        },
        {
            value: "Lund"
        },
        {
            value: "Kiruna"
        }
    ],
    "United Kingdom": [
        {
            value: "Bristol"
        },
        {
            value: "Manchester"
        },
        {
            value: "Nottingham"
        },
        {
            value: "Sheffield"
        }
    ],
}
var countries = [
    {
        value: "Austria",
        src: "../common/flags/at.png"
    },
    {
        value: "Belgium",
        src: "../common/flags/be.png"
    },
    {
        value: "Bulgaria",
        src: "../common/flags/bg.png"
    },
    {
        value: "Cyprus",
        src: "../common/flags/cy.png"
    },
    {
        value: "Czech Republic",
        src: "../common/flags/cz.png"
    },
    {
        value: "Denmark",
        src: "../common/flags/dk.png"
    },
    {
        value: "Estonia",
        src: "../common/flags/ee.png"
    },
    {
        value: "Finland",
        src: "../common/flags/fi.png"
    },
    {
        value: "France",
        src: "../common/flags/fr.png"
    },
    {
        value: "Germany",
        src: "../common/flags/de.png"
    },
    {
        value: "Greece",
        src: "../common/flags/gr.png"
    },
    {
        value: "Hungary",
        src: "../common/flags/hu.png"
    },
    {
        value: "Ireland",
        src: "../common/flags/ie.png"
    },
    {
        value: "Italy",
        src: "../common/flags/it.png"
    },
    {
        value: "Latvia",
        src: "../common/flags/lv.png"
    },
    {
        value: "Lithuania",
        src: "../common/flags/lt.png"
    },
    {
        value: "Luxembourg",
        src: "../common/flags/lu.png"
    },
    {
        value: "Malta",
        src: "../common/flags/mt.png"
    },
    {
        value: "Netherlands",
        src: "../common/flags/nl.png"
    },
    {
        value: "Poland",
        src: "../common/flags/pl.png"
    },
    {
        value: "Portugal",
        src: "../common/flags/pt.png"
    },
    {
        value: "Romania",
        src: "../common/flags/ro.png"
    },
    {
        value: "Slovakia",
        src: "../common/flags/sk.png"
    },
    {
        value: "Slovenia",
        src: "../common/flags/si.png"
    },
    {
        value: "Spain",
        src: "../common/flags/es.png"
    },
    {
        value: "Sweden",
        src: "../common/flags/se.png"
    },
    {
        value: "United Kingdom",
        src: "../common/flags/gb.png"
    }
];


var iconData = [
    {
        icon: "dxi dxi-weather-cloudy",
        value: "Cloudy"
    },
    {
        icon: "dxi dxi-weather-hail",
        value: "Hail"
    },
    {
        icon: "dxi dxi-weather-sunny",
        value: "Sunny"
    },
    {
        icon: "dxi dxi-weather-cloudy",
        value: "Windy"
    },
    {
        icon: "dxi dxi-weather-cloudy",
        value: "Lighting"
    },
    {
        icon: "dxi dxi-weather-cloudy",
        value: "Clear Night"
    },
    {
        icon: "dxi dxi-weather-cloudy",
        value: "Party Cloudy"
    }
];