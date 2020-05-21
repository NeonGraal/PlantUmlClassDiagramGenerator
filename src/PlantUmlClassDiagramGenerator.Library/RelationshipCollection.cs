﻿using System.Collections;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace PlantUmlClassDiagramGenerator.Library
{
    public class RelationshipCollection : IEnumerable<Relationship>
    {
        private IList<Relationship> _items = new List<Relationship>();

        public void AddInheritanceFrom(TypeDeclarationSyntax syntax)
        {
            if (syntax.BaseList == null) return;

            var subTypeName = TypeNameText.From(syntax);

            foreach (var typeStntax in syntax.BaseList.Types)
            {
                var typeNameSyntax = typeStntax.Type as SimpleNameSyntax;
                if (typeNameSyntax == null) continue;
                var baseTypeName = TypeNameText.From(typeNameSyntax);
                _items.Add(new Relationship(baseTypeName, subTypeName, "<|--", baseTypeName.TypeArguments));             
            }
        }

        public void AddInnerclassRelationFrom(SyntaxNode node)
        {
            var outerTypeNode = node.Parent as BaseTypeDeclarationSyntax;
            var innerTypeNode = node as BaseTypeDeclarationSyntax;

            if (outerTypeNode == null || innerTypeNode == null) return;

            var outerTypeName = TypeNameText.From(outerTypeNode);
            var innerTypeName = TypeNameText.From(innerTypeNode);
            _items.Add(new Relationship(outerTypeName, innerTypeName, "+--"));
        }

        public void AddAssociationFrom(FieldDeclarationSyntax node, VariableDeclaratorSyntax field)
        {
            var baseNode = node.Declaration.Type as SimpleNameSyntax;
            var subNode = node.Parent as BaseTypeDeclarationSyntax;

            if (baseNode == null || subNode == null) return;
            AddAssociationFrom(subNode, baseNode, field.Initializer, field.Identifier);
        }

        public void AddAssociationFrom(ConstructorDeclarationSyntax node, ParameterSyntax parameter)
        {
            var baseNode = parameter.Type as SimpleNameSyntax;
            var subNode = node.Parent as BaseTypeDeclarationSyntax;

            if (baseNode == null || subNode == null) return;
            AddAssociationFrom(subNode, baseNode, parameter.Default, parameter.Identifier);
        }

        public void AddAssociationFrom(PropertyDeclarationSyntax node)
        {
            var baseNode = node.Type as SimpleNameSyntax;
            var subNode = node.Parent as BaseTypeDeclarationSyntax;

            if (baseNode == null || subNode == null) return;
            AddAssociationFrom(subNode, baseNode, node.Initializer, node.Identifier);
        }

        private void AddAssociationFrom(BaseTypeDeclarationSyntax subNode, SimpleNameSyntax baseNode, EqualsValueClauseSyntax init, SyntaxToken identifier) 
        {
            var symbol = init == null ? "-->" : "o->";
            var baseName = TypeNameText.From(baseNode);
            var subName = TypeNameText.From(subNode);
            _items.Add(new Relationship(subName, baseName, symbol, "", identifier.ToString() + baseName.TypeArguments));
        }

        public IEnumerator<Relationship> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
