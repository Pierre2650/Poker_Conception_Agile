using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**@file
*@brief Class Description: Script Qui va permetre l'enregistrement et mise en forme des taches dedans un backlog.
*/

[Serializable]
public class Backlog_Information
{
    /**@class Backlog_Information.
  * @brief Classe qui sert comme conteneur d'information d'une tache
  * 
  * @var string Role
  * @brief Definit le role de la personne qui fait la tache
  * 
  * @var string Task
  * @brief Decrit la tache en question
  * 
  * @var string Obj
  * @brief Decrit l'objective de la tache
  * 
  * @var string Value
  * @brief Definit la evaluation donne, si la valeur est egale a "None" la tache n'est pas encore Evaluee.
  *
  */

    public string Role;
    public string Task;
    public string Obj;
    public string Value;

}
