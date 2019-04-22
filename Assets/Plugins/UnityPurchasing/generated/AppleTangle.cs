#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class AppleTangle
    {
        private static byte[] data = System.Convert.FromBase64String("aQoIectIa3lET0BjzwHPvkRISEhpKCctaSosOz0gLyAqKD0gJidpOXnLTfJ5y0rq6UpLSEtLSEt5RE9AZWkqLDs9IC8gKig9LGk5JiUgKjB6fxN5K3hCeUBPShxNT1pLHBp4Wi7GQf1pvoLlZWkmOf92SHnF/gqGTElKy0hGSXnLSENLy0hISa3Y4EBjzwHPvkRISExMSXkreEJ5QE9KHEFiT0hMTE5LSF9XIT09OTpzZmY+y0hJT0BjzwHPviotTEh5yLt5Y0+JKno+vnNOZR+ik0ZoR5PzOlAG/DklLGkbJiY9aQoIeVdeRHl/eX17LXxqXAJcEFT63b6/1deGGfOIERlWzMrMUtB0Dn674NIJx2Wd+NlbkX/QBWQx/qTF0pW6PtK7P5s+eQaIyV1imSAO3T9At70ixGcJ774OBDYQ7kxANV4JH1hXPZr+wmpyDuqcJjklLGkKLDs9IC8gKig9ICYnaQg8PSAvICooPSxpKzBpKCcwaTkoOz1veW1PShxNQlpUCDk5JSxpCiw7PU6lNHDKwhppmnGN+PbTBkMitmK1PSEmOyA9MHhfeV1PShxNSlpECDkrJSxpOj0oJy0oOy1pPSw7JDppKAw3VgUiGd8IwI09K0JZygjOesPIT3lGT0ocVFpISLZNTHlKSEi2eVQlLGkAJypneG95bU9KHE1CWlQIOWkmL2k9ISxpPSEsJ2koOTklICooZwnvvg4ENkEXeVZPShxUak1ReV8+PmcoOTklLGcqJiRmKDk5JSwqKEbUdLpiAGFTgbeH/PBHkBdVn4J04ZU3a3yDbJyQRp8inettali+6OUzectIP3lHT0ocVEZISLZNTUpLSE1PWkscGnhaeVhPShxNQ1pDCDk5dG8uacN6I75Ey4aXoupmsBojEi1BF3nLSFhPShxUaU3LSEF5y0hNeZB/NojOHJDu0PB7C7KRnDjXN+gb+HkRpRNNe8Uh+sZUlyw6ti4XLPVPShxUR01fTV1imSAO3T9At70ixMY6yCmPUhJAZtv7sQ0BuSlx11y8AJE/1npdLOg+3YBkS0pISUjqy0hfeV1PShxNSlpECDk5JSxpGyYmPSctaSomJy0gPSAmJzppJi9pPDosZnnIik9BYk9ITExOS0t5yP9TyPqAUDu8FEecNhbSu2xK8xzGBBREuERPQGPPAc++REhITExJSstISEkVwlDAl7ACJbxO4mt5S6FRd7EZQJobLCUgKCcqLGkmJ2k9ISA6aSosO+LqONsOGhyI5mYI+rGyqjmEr+oFbauimP45lkYMqG6DuCQxpK78Xl7c1zNF7Q7CEp1ffnqCjUYEh10gmDsoKj0gKixpOj0oPSwkLCc9Omd5Ngjh0bCYgy/VbSJYmeryrVJjilb+UvTaC21bY45GVP8E1RcqgQLJXnx7eH15en8TXkR6fHl7eXB7eH15eVhPShxNQ1pDCDk5JSxpACcqZ3j8c+S9RkdJ20L4aF9nPZx1RJIrX/e9OtKnmy1GgjAGfZHrd7AxtiKBVtiSVw4ZokykFzDNZKJ/6x4FHKUgLyAqKD0gJidpCDw9ISY7ID0weDBpKDo6PCQsOmkoKiosOT0oJyosGePDnJOttZlATn75PDxo");
        private static int[] order = new int[] { 13,45,13,44,8,21,14,45,35,34,57,14,20,49,48,32,52,35,39,57,51,21,42,25,29,44,41,31,36,42,54,36,49,56,56,58,41,54,55,41,51,43,54,57,47,52,55,54,53,57,55,58,59,59,56,56,56,57,59,59,60 };
        private static int key = 73;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
