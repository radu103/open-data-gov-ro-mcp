namespace OpenDataGovRo.Tools
{
    public static class DataGovRoUrls
    {
        public static List<KeyValuePair<string, string>> Items = new List<KeyValuePair<string, string>>()
        {
            // Date Urbanism
            new KeyValuePair<string, string>("urbanism_autorizatii_construire_2024", "https://data.gov.ro/dataset/8ec8ac7f-3631-431b-91a7-b0cf6a3867f1/resource/a35d7203-3a35-422f-af83-c2fe0b6e2661/download/2024-ac.xlsx"),
            new KeyValuePair<string, string>("urbanism_certificate_urbanism_2024", "https://data.gov.ro/dataset/cd3937b1-781b-4d7f-bb7a-f7345bf31b0d/resource/32d7eee1-854c-4e5f-a290-ad307d993b25/download/cu-2024.xlsx"),

            // Date administrative
            new KeyValuePair<string, string>("admin_firme_neradiate", "https://data.gov.ro/dataset/11b4e62a-daa9-4093-b9a9-5c5ca259a096/resource/2cb08cf2-258d-4334-b572-0ea33e04d62a/download/3firme_neradiate_cu_sediu_18-03-2025.csv"),
            new KeyValuePair<string, string>("admin_firme_radiate", "https://data.gov.ro/dataset/11b4e62a-daa9-4093-b9a9-5c5ca259a096/resource/2cb08cf2-258d-4334-b572-0ea33e04d62a/download/3firme_radiate_cu_sediu_18-03-2025.csv"),
            new KeyValuePair<string, string>("admin_siruta_uat", "http://data.gov.ro/storage/f/2013-11-01T11%3A49%3A59.808Z/siruta.csv"),
            new KeyValuePair<string, string>("admin_siruta_judete", "http://data.gov.ro/storage/f/2013-11-01T11%3A53%3A13.359Z/siruta-judete.csv"),
            new KeyValuePair<string, string>("admin_siruta_zone", "http://data.gov.ro/storage/f/2013-11-01T11%3A52%3A07.473Z/siruta-zone.csv"),
            
            // Date demografice
            new KeyValuePair<string, string>("demografie_populatie_localitati", "https://data.gov.ro/dataset/8c865473-6855-448c-ac3d-ce535f7a8c58/resource/ffeed201-5a5e-4c85-95fa-4f5ef655e7ed/download/pop108d.csv"),
            new KeyValuePair<string, string>("demografie_populatie_judete", "https://data.gov.ro/dataset/8c865473-6855-448c-ac3d-ce535f7a8c58/resource/bf017231-7384-4826-8c1d-d1fca330cc96/download/pop108c.csv"),
            
            // Date economice
            new KeyValuePair<string, string>("economie_somaj_pe_judete", "https://data.gov.ro/dataset/f3b14a48-fcca-4635-a2f9-2d8e4f85ce05/resource/19d59f1e-2c65-4036-9b69-2b463599a0c9/download/somaj102e.csv"),
            new KeyValuePair<string, string>("economie_salariati_pe_judete", "https://data.gov.ro/dataset/3e2889d9-67f7-44d6-87f3-df79579f5790/resource/ee10d157-a998-476d-b28a-04a1df53564c/download/fom104d.csv"),
            new KeyValuePair<string, string>("economie_bugetari_pe_judete", "https://data.gov.ro/dataset/59b9f8a7-10f8-44ac-8c18-62f8367db945/resource/60892575-8ecc-43e2-97d1-55f251a314c3/download/efectiv-personal-bugetar-31.03.2023.csv"),
            
            // Date geospațiale
            new KeyValuePair<string, string>("geo_unitati_administrative", "https://data.gov.ro/dataset/28a5b158-53a3-4908-a291-60da9cd33e90/resource/89bd5018-2ea0-4b81-a345-3fde7c9c0739/download/uatpolygontranslated.csv"),
            
            // Date de mediu
            new KeyValuePair<string, string>("mediu_calitate_aer", "https://data.gov.ro/dataset/calitatea-aerului-date-orare/resource/5675dc88-75e9-4adb-a9f7-9888b6fa1857/download/date_orare_2024.csv"),
            new KeyValuePair<string, string>("mediu_arii_protejate", "https://data.gov.ro/dataset/b266e073-2fc4-4d18-8c1b-4ebcfbf5803b/resource/097a1fa4-585e-46ec-bcbd-6b7445a4a670/download/lista_siturilor_natura_2000_din_romania_1_dec_2017.csv"),
            
            // Date din domeniul sănătății
            new KeyValuePair<string, string>("sanatate_spitale", "https://data.gov.ro/dataset/4b24084e-e4e6-4391-96de-c578831c1f16/resource/7a5a5ded-ceb4-4635-b142-ddbfdb93f295/download/lista_spitalelor_publice_actualizata_20150701.csv"),
            new KeyValuePair<string, string>("sanatate_covid19_cazuri", "https://data.gov.ro/dataset/transparenta-covid/resource/b8ca5e9a-a055-41e9-8913-2aeaf986d30d/download/date_covid19_tari.csv"),
            
            // Date din domeniul educației
            new KeyValuePair<string, string>("educatie_scoli", "https://data.gov.ro/dataset/119c7466-ef6c-43ac-8b14-08d5902df912/resource/123b59a3-0c30-4914-a3b7-307018ce31d9/download/siiir-2023-01-17.csv"),
            
            // Date din domeniul transporturilor
            new KeyValuePair<string, string>("transport_drumuri_nationale", "https://data.gov.ro/dataset/situatia-drumurilor-naționale/resource/2a4485b9-345c-4f75-a373-af0faed538d0/download/situatie_dn_31.05.2023.csv"),
            
            // Date din domeniul justiției
            new KeyValuePair<string, string>("justitie_infractiuni", "https://data.gov.ro/dataset/e44a1622-c5f3-423f-9083-7caa3caa45d4/resource/de937b2d-c28d-4030-a6e9-c97f733678cb/download/infractiuni.csv"),
            
            // Date despre servicii publice
            new KeyValuePair<string, string>("servicii_primarii", "http://data.gov.ro/storage/f/2013-11-06T12%3A05%3A03.166Z/primarii.csv"),
            
            // Date financiare
            new KeyValuePair<string, string>("financiar_salarii_bugetari", "https://data.gov.ro/dataset/e44e4506-9c48-4866-bdeb-91926456f958/resource/a868ccc5-8354-4645-af71-59d6c2c1db9e/download/anaf_salmed_2022.csv"),
            
            // Date financiare și bugetare
            new KeyValuePair<string, string>("financiar_executie_bugetara_2023", "https://data.gov.ro/dataset/9357c61d-2a75-4d0b-970e-34ccc3daf2ce/resource/4b5de969-d274-499b-a0e9-05430324cae5/download/executiebugetara_31.12.2023.xlsx"),
            new KeyValuePair<string, string>("financiar_executie_bugetara_2024", "https://data.gov.ro/dataset/9357c61d-2a75-4d0b-970e-34ccc3daf2ce/resource/d14c918e-0aef-4217-83c2-c69b7d39001f/download/executiebugetara_31.03.2025.xlsx"),
            new KeyValuePair<string, string>("financiar_investitii_publice_2024", "https://data.gov.ro/dataset/25c9b382-8962-4966-96ac-989b0ca7ec00/resource/8aa16c5d-7802-4e51-809c-136b6a19d85b/download/investitii_publice_semnificative_martie_2025.xlsx"),
            new KeyValuePair<string, string>("financiar_buget_2025", "https://data.gov.ro/dataset/caen-bugetare/resource/42e452bd-2b29-45f0-931a-2ed7837ca350/download/bugetare_2025.xlsx"),
            
            // Date privind funcționarii publici
            new KeyValuePair<string, string>("admin_functionari_2023", "https://data.gov.ro/dataset/functii-exercitate-temporar/resource/c76f9eee-5ad8-455d-9192-33b2f2c23532/download/functii_exercitate_temporar_2023.xlsx"),
            new KeyValuePair<string, string>("admin_sanctiuni_functionari_2023", "https://data.gov.ro/dataset/sanctiuni-disciplinare/resource/d2befb40-9911-45ae-9628-040e913ffc2e/download/sanctiuni_disciplinare_2023.xlsx"),
            new KeyValuePair<string, string>("admin_concursuri_functionari_2024", "https://data.gov.ro/dataset/concursuri-functii-publice-anf/resource/f378dd5a-2250-4af0-9d62-0a50a3d7253e/download/concursuri_functii_publice_actualizare_15.04.2025.xlsx"),
            
            // Date privind educația
            new KeyValuePair<string, string>("educatie_rezultate_evaluare_nationala_2024", "https://data.gov.ro/dataset/rezultate-evaluare-nationala/resource/fc0d8852-2c3c-4bbb-91cf-76bd22258388/download/evaluare_nationala_2024_rezultate.xlsx"),
            new KeyValuePair<string, string>("educatie_rezultate_bacalaureat_2024", "https://data.gov.ro/dataset/rezultate-bacalaureat/resource/5d0cb606-146b-4d9e-9575-39ce3aafdebc/download/rezultate_bacalaureat_2024.xlsx"),
            new KeyValuePair<string, string>("educatie_retea_scolara_2024_2025", "https://data.gov.ro/dataset/reteaua-scolara-nationala/resource/9bd91b6e-7dd0-4171-9805-f67250fc0536/download/retea_scolara_2024_2025.xlsx"),
            
            // Date privind sănătatea
            new KeyValuePair<string, string>("sanatate_indicatori_spitale_2023", "https://data.gov.ro/dataset/indicatori-spitale/resource/7d74a15c-fd63-4f1e-8b88-b7a0c5c84448/download/indicatori_spitale_2023.xlsx"),
            new KeyValuePair<string, string>("sanatate_medicamente_compensate_2024", "https://data.gov.ro/dataset/medicamente-compensate/resource/8caab8d2-e561-4a99-8265-531bd62e3a1c/download/lista_medicamente_compensate_2024.xlsx"),
            new KeyValuePair<string, string>("sanatate_centre_vaccinare_covid", "https://data.gov.ro/dataset/centre-vaccinare-covid/resource/78bd8e0a-bcf6-43ef-9bf3-5d12975fc159/download/centre_vaccinare_covid19_romania.xlsx"),
            
            // Date privind infrastructura
            new KeyValuePair<string, string>("infra_proiecte_pnrr_2024", "https://data.gov.ro/dataset/proiecte-pnrr/resource/e45b6c85-2b5c-4f68-a6e5-f9c0e662e9e3/download/proiecte_finantate_pnrr_martie_2025.xlsx"),
            new KeyValuePair<string, string>("infra_proiecte_anghel_saligny", "https://data.gov.ro/dataset/proiecte-anghel-saligny/resource/db982c5c-4e0b-4288-b8b6-50f0cc9a5df5/download/lista_proiecte_anghel_saligny_2024.xlsx"),
            new KeyValuePair<string, string>("infra_infrastructura_rutiera_2024", "https://data.gov.ro/dataset/infrastructura-rutiera/resource/09c26fc3-9952-4a55-9ce7-8130fc23d463/download/situatie_infrastructura_rutiera_2024.xlsx"),
            
            // Date privind mediul de afaceri
            new KeyValuePair<string, string>("business_firme_nou_infiintate_2024", "https://data.gov.ro/dataset/firme-nou-infiintate/resource/6e612de2-d9bd-49f6-8c23-3c6e62b36f74/download/firme_nou_infiintate_q1_2025.xlsx"),
            new KeyValuePair<string, string>("business_ajutoare_stat_2024", "https://data.gov.ro/dataset/ajutoare-de-stat/resource/a3d5ca90-0c71-487d-a72e-4a067766550f/download/ajutoare_stat_acordate_2024.xlsx"),
            new KeyValuePair<string, string>("business_IMM_innovative_2024", "https://data.gov.ro/dataset/imm-inovative/resource/f2ed9b4a-e8d-4cb4-b39a-747c5d05849d/download/lista_imm_inovative_2024.xlsx"),
            
            // Date privind piața muncii
            new KeyValuePair<string, string>("munca_locuri_munca_vacante_2025", "https://data.gov.ro/dataset/locuri-munca-vacante/resource/3c9a8bdb-4a6f-4b71-a6d0-7df4d0b2a714/download/locuri_munca_vacante_aprilie_2025.xlsx"),
            new KeyValuePair<string, string>("munca_salarii_sectoare_2024", "https://data.gov.ro/dataset/salarii-sectoare-economie/resource/b41d5e1c-f8e7-4f1b-8cb5-e8416bc1d068/download/salarii_medii_sectoare_economie_2024.xlsx"),
            new KeyValuePair<string, string>("munca_somaj_2024_judete", "https://data.gov.ro/dataset/somaj-rate-judetene/resource/0a7eb171-c95d-49e1-9e74-27038d6c0a11/download/rate_somaj_judete_martie_2025.xlsx"),
            
            // Date privind turismul
            new KeyValuePair<string, string>("turism_structuri_cazare_2024", "https://data.gov.ro/dataset/structuri-cazare-turistica/resource/f4e2fee4-8124-4a5f-b511-2ca9d05c15c1/download/structuri_cazare_clasificate_2024.xlsx"),
            new KeyValuePair<string, string>("turism_sosiri_turisti_2024", "https://data.gov.ro/dataset/turism-sosiri/resource/a47b51d8-f49c-403d-9a33-1bc051340328/download/sosiri_turisti_2024.xlsx"),
            new KeyValuePair<string, string>("turism_destinatii_turistice_2024", "https://data.gov.ro/dataset/destinatii-turistice/resource/e5a8867e-ef31-469c-adce-0482a2d42815/download/destinatii_turistice_romania_2024.xlsx"),
            
            // Date privind agricultura
            new KeyValuePair<string, string>("agri_subventii_agricole_2024", "https://data.gov.ro/dataset/subventii-agricultura/resource/0086c8c0-55be-45db-9bc7-51611d0fdef2/download/subventii_agricultura_2024.xlsx"),
            new KeyValuePair<string, string>("agri_productie_agricola_2023", "https://data.gov.ro/dataset/productie-agricola/resource/62b42dae-c75d-47e4-93d5-a8c849e5c098/download/productie_agricola_2023.xlsx"),
            new KeyValuePair<string, string>("agri_ferme_ecologice_2024", "https://data.gov.ro/dataset/agricultura-ecologica/resource/634f85a5-36c0-4e13-b83b-573c06461d43/download/ferme_certificate_ecologic_2024.xlsx"),
        };
    }
}