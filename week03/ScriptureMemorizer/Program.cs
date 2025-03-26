using System;

class Program
{
   
using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public Reference GetReference() => _reference;
    public List<Word> GetWords() => _words;
    public int GetHiddenWordCount() => _words.Count(w => w.IsHidden());

    public void HideRandomWords(int numberToHide)
    {
        Random rand = new Random();
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        
        for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)
        {
            Word word = visibleWords[rand.Next(visibleWords.Count)];
            word.Hide();
            visibleWords.Remove(word);
        }
    }

    public string GetDisplayText()
    {
        return _reference.GetDisplayText() + " - " + string.Join(" ", _words.Select(w => w.GetDisplayText()));
    }

    public bool IsCompletelyHidden() => _words.All(w => w.IsHidden());
}

class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide() => _isHidden = true;
    public void Show() => _isHidden = false;
    public bool IsHidden() => _isHidden;
    public string GetText() => _text;

    public string GetDisplayText() => _isHidden ? new string('_', _text.Length) : _text;
}

class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int? _endVerse;

    public Reference(string book, int chapter, int verse, int? endVerse = null)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    public string GetBook() => _book;
    public int GetChapter() => _chapter;
    public int GetVerse() => _verse;
    public int? GetEndVerse() => _endVerse;

    public string GetDisplayText()
    {
        return _endVerse.HasValue ? $"{_book} {_chapter}:{_verse}-{_endVerse}" : $"{_book} {_chapter}:{_verse}";
    }
}

}