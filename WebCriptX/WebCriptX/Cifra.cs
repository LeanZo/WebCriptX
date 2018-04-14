using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCriptX
{
    public class Cifra
    {
        static string[,] gerarCifra()
        {
            int i3 = 0;

            string[] letrasBasicas = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            string[,] cifraVigenere = new string[26, 26]; //[linha, coluna]

            for (int i = 0; i <= 25; i++)
            {

                for (int i2 = 0; i2 <= 25; i2++)
                {
                    if (i == 0)
                    {
                        cifraVigenere[i2, i] = letrasBasicas[i2];
                    }
                    else
                    {
                        if ((i2 + i) > 25)
                        {
                            cifraVigenere[i2, i] = letrasBasicas[i3];
                            i3++;
                        }
                        else
                        {
                            cifraVigenere[i2, i] = letrasBasicas[i2 + i];
                        }

                    }
                }
                i3 = 0;
            }

            return cifraVigenere;
        }

        public static string[] encriptar(string[] fileLines, string palavraChave)
        {
            string[,] cifraVigenere = gerarCifra();
            string[] letrasBasicas = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int colunaID = 666;
            int linhaID = 666;
            string fraseEncriptada = null;
            int palavraChaveIndex = 0;
            int fileLinesEncriptadoIndex = 0;
            string[] fileLinesEncriptado = new string[fileLines.Length];

            foreach (string linha in fileLines)
            {
                foreach (char letra in linha)
                {
                    foreach (string alfabeto in letrasBasicas)
                    {
                        if (Convert.ToString(letra).ToUpper() == alfabeto)
                        {
                            colunaID = Array.IndexOf(letrasBasicas, alfabeto.ToUpper());
                            if (palavraChaveIndex < (palavraChave.Length))
                            {
                                linhaID = Array.IndexOf(letrasBasicas, Convert.ToString(palavraChave[palavraChaveIndex]));
                                palavraChaveIndex++;
                            }
                            else
                            {
                                palavraChaveIndex = 0;
                                linhaID = Array.IndexOf(letrasBasicas, Convert.ToString(palavraChave[palavraChaveIndex]));
                                palavraChaveIndex++;
                            }
                            break;
                        }
                    }
                    if (colunaID != 666)
                    {
                        if (Char.IsUpper(letra))
                        {
                            fraseEncriptada = fraseEncriptada + cifraVigenere[linhaID, colunaID];
                        }
                        else
                        {
                            fraseEncriptada = fraseEncriptada + cifraVigenere[linhaID, colunaID].ToLower();
                        }
                        colunaID = 666;
                    }
                    else
                    {
                        fraseEncriptada = fraseEncriptada + letra;
                    }
                }
                fileLinesEncriptado[fileLinesEncriptadoIndex] = fraseEncriptada;
                fraseEncriptada = null;
                fileLinesEncriptadoIndex++;
            }


            return fileLinesEncriptado;
        }

        public static string[] decriptar(string[] fileLines, string palavraChave)
        {
            string[,] cifraVigenere = gerarCifra();
            string[] letrasBasicas = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int colunaID = 666;
            int linhaID = 666;
            string fraseDecriptada = null;
            int palavraChaveIndex = 0;
            int fileLinesDecriptadoIndex = 0;
            string[] fileLinesDecriptado = new string[fileLines.Length];
            bool isLetra = false;

            foreach (string linha in fileLines)
            {
                foreach (char letra in linha)
                {
                    isLetra = false;
                    foreach (string alfabeto in letrasBasicas)
                    {
                        if (Convert.ToString(letra).ToUpper() == alfabeto)
                        {
                            isLetra = true;
                            break;
                        }
                    }

                    if (isLetra)
                    {
                        if (palavraChaveIndex < (palavraChave.Length))
                        {
                            linhaID = Array.IndexOf(letrasBasicas, Convert.ToString(palavraChave[palavraChaveIndex]));
                            palavraChaveIndex++;
                        }
                        else
                        {
                            palavraChaveIndex = 0;
                            linhaID = Array.IndexOf(letrasBasicas, Convert.ToString(palavraChave[palavraChaveIndex]));
                            palavraChaveIndex++;
                        }

                        for (int i = 0; i <= 25; i++)
                        {
                            if (Convert.ToString(letra).ToUpper() == cifraVigenere[linhaID, i])
                            {
                                colunaID = i;
                                break;
                            }

                        }

                        if (Char.IsUpper(letra))
                        {
                            fraseDecriptada = fraseDecriptada + letrasBasicas[colunaID];
                        }
                        else
                        {
                            fraseDecriptada = fraseDecriptada + letrasBasicas[colunaID].ToLower();
                        }
                    }
                    else
                    {
                        fraseDecriptada = fraseDecriptada + letra;
                    }
                }

                fileLinesDecriptado[fileLinesDecriptadoIndex] = fraseDecriptada;
                fraseDecriptada = null;
                fileLinesDecriptadoIndex++;
            }

            return fileLinesDecriptado;
        }

    }
}
