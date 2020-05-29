using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System;
using GameStory;
using UnityEngine;

public class ConversationBuilder
{
    private IDataSetBuilder _dataSetBuilder;
    private DataSet _dataSet;
    private ConversationsDatabase _conversationsDatabase;

    public ConversationBuilder(IDataSetBuilder dataSetBuilder)
    {
        _dataSet = dataSetBuilder.BuildDataSet();

        _conversationsDatabase = ScriptableObject.CreateInstance<ConversationsDatabase>();

        _conversationsDatabase.locations = ParseLocations();
        _conversationsDatabase.gameCharacters = ParseGameCharacters();
        _conversationsDatabase.conversationLines = ParseConversationLines();
    }

    private List<Location> ParseLocations()
    {
        DataTable locationTable = _dataSet.Tables["Locations"];

        var locationList = new List<Location>();
        foreach (DataRow dataRow in locationTable.AsEnumerable())
        {
            locationList.Add(dataRow.Field<string>("LocationName"));
        }

        return locationList;
    }

    private List<GameCharacter> ParseGameCharacters()
    {
        var gameCharacters = new List<GameCharacter>();
        var characters = _dataSet.Tables["Characters"];
        foreach (DataRow dataRow in characters.AsEnumerable())
        {
            var characterName = dataRow.Field<string>("CharacterName");


            var characterLocation = _conversationsDatabase.locations
                .Find(l => l.locationName == FindTableValueByKey(_dataSet.Tables["Locations"],
                               dataRow.Field<Int64>("CharacterLocation"), "LocationName"));

            Sex characterSex;
            Enum.TryParse(
                FindTableValueByKey(_dataSet.Tables["Sexes"], dataRow.Field<Int64>("CharacterSex"), "SexName"),
                out characterSex);

            var characterPersonalObject = new PersonalObject(FindTableValueByKey(
                _dataSet.Tables["PersonalObjects"], dataRow.Field<Int64>("ID"),
                "PersonalObjectName", "Owner"));
            var newCharacter =
                new GameCharacter(characterName, characterLocation, characterSex, characterPersonalObject);
            gameCharacters.Add(newCharacter);

            Debug.Log(newCharacter.ToString());
        }

        return null;
    }

    private List<ConversationLine> ParseConversationLines()
    {
        throw new NotImplementedException();
        
        var conversationLineList=new List<ConversationLine>();

        foreach (DataRow row in _dataSet.Tables["AnswerClues"].AsEnumerable())
        {
//            conversationLineList.Add(new ConversationLine());
        }

        return conversationLineList;
    }

    private string FindTableValueByKey(DataTable lookupTable, Int64 key, string foreignKeyFieldName,
        string primaryKeyName = "ID")
    {
        try
        {
            var foundValue = lookupTable.AsEnumerable()
                .Where(t => t.Field<Int64>(primaryKeyName) == key)
                .Select(t => t.Field<string>(foreignKeyFieldName))
                .First().ToString();
            return foundValue;
        }
        catch (Exception ex)
        {
            Debug.LogWarning(ex);
        }

        return null;
    }
}