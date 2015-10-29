using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Windows.Forms
{
    public abstract partial class Control : Component, IComponent, IDisposable
    {
        /// <summary>
        /// Represents a collection of <see cref="Control"/> objects.
        /// Is not actually inherited from ArrangedElementCollection. ArrangedElementCollection was removed from this implementation.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection(v=vs.110).aspx
        /// </remarks>
        [ListBindable(false)]
        public class ControlCollection : IEnumerable, ICloneable, IList, ICollection
        {
            private readonly object _syncRoot = new object();
            private readonly object _internalSyncRoot = new object();

            private readonly List<Control> _controls;
            private readonly Control _owner;

            #region Constructors
            /// <summary>
            /// Initializes a new instance of the <see cref="ControlCollection"/> class.
            /// </summary>
            /// <param name="owner">A <see cref="Control"/> representing the control that owns the control collection.</param>
            public ControlCollection(Control owner)
            {
                _owner = owner;
                _controls = new List<Control>();
            }

            private ControlCollection(Control owner, List<Control> controls)
                : this(owner)
            {
                _controls = controls;
            }
            #endregion

            #region Properties
            /// <summary>
            /// Gets the number of elements in the collection.
            /// </summary>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.layout.arrangedelementcollection.count(v=vs.110).aspx
            /// </remarks>
            public virtual int Count
            {
                get
                {
                    lock (_internalSyncRoot)
                    {
                        return _controls.Count;
                    }
                }
            }

            /// <summary>
            /// Gets a value indicating whether the collection is read-only.
            /// </summary>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.layout.arrangedelementcollection.isreadonly(v=vs.110).aspx
            /// </remarks>
            public virtual bool IsReadOnly => false;

            /// <summary>
            /// Indicates the <see cref="Control"/> at the specified indexed location in the collection.
            /// </summary>
            /// <param name="index">The index of the control to retrieve from the control collection.</param>
            /// <returns>The <see cref="Control"/> located at the specified index location within the control collection.</returns>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/333f9hk4(v=vs.110).aspx
            /// </remarks>
            public virtual Control this[int index]
            {
                get
                {
                    lock (_internalSyncRoot)
                    {
                        return _controls[index];
                    }
                }
            }

            /// <summary>
            /// Indicates a <see cref="Control"/> with the specified key in the collection.
            /// </summary>
            /// <param name="key">The name of the control to retrieve from the control collection.</param>
            /// <returns>The <see cref="Control"/> with the specified key within the <see cref="ControlCollection"/>.</returns>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/s1865435(v=vs.110).aspx
            /// </remarks>
            public virtual Control this[string key]
            {
                get
                {
                    lock (_internalSyncRoot)
                    {
                        foreach (Control c in _controls)
                        {
                            if (c.Name == key)
                            {
                                return c;
                            }
                        }

                        throw new KeyNotFoundException();
                    }
                }
            }

            /// <summary>
            /// Gets the control that owns this <see cref="ControlCollection"/>.
            /// </summary>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.owner(v=vs.110).aspx
            /// </remarks>
            public Control Owner => _owner;
            #endregion

            #region Methods
            /// <summary>
            /// Adds the specified control to the control collection.
            /// </summary>
            /// <param name="value">The <see cref="Control"/> to add to the control collection.</param>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.add(v=vs.110).aspx
            /// </remarks>
            public virtual void Add(Control value)
            {
                lock (_internalSyncRoot)
                {
                    InternalAdd(value);
                }
            }

            private void InternalAdd(Control value)
            {
                if (_owner == value)
                {
                    throw new ArgumentException($"The control {nameof(value)} cannot be the same as the {nameof(Owner)}.");
                }

                value.TabIndex = _controls.Count;
                _controls.Add(value);
                value.Parent = _owner;
            }

            /// <summary>
            /// Adds an array of control objects to the collection.
            /// </summary>
            /// <param name="controls">An array of <see cref="Control"/> objects to add to the collection.</param>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.addrange(v=vs.110).aspx
            /// </remarks>
            public virtual void AddRange(Control[] controls)
            {
                foreach (Control control in controls)
                {
                    Add(control);
                }
            }

            /// <summary>
            /// Removes all controls from the collection.
            /// </summary>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.clear(v=vs.110).aspx
            /// </remarks>
            public virtual void Clear()
            {
                lock (_internalSyncRoot)
                {
                    _controls.Clear();
                }
            }

            /// <summary>
            /// Determines whether the specified control is a member of the collection.
            /// </summary>
            /// <param name="control">The <see cref="Control"/> to locate in the collection.</param>
            /// <returns>true if the <see cref="Control"/> is a member of the collection; otherwise, false.</returns>
            public bool Contains(Control control)
            {
                lock (_internalSyncRoot)
                {
                    return _controls.Contains(control);
                }
            }

            /// <summary>
            /// Determines whether the <see cref="ControlCollection"/> contains an item with the specified key.
            /// </summary>
            /// <param name="key">The key to locate in the <see cref="Control.ControlCollection"/>.</param>
            /// <returns>true if the <see cref="ControlCollection"/> contains an item with the specified key; otherwise, false.</returns>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.containskey(v=vs.110).aspx
            /// </remarks>
            public virtual bool ContainsKey(string key)
            {
                lock (_internalSyncRoot)
                {
                    foreach (Control c in _controls)
                    {
                        if (c.Name == key)
                        {
                            return true;
                        }
                    }

                    return false;
                }
            }

            /// <summary>
            /// Copies the entire contents of this collection to a compatible one-dimensional <see cref="Array"/>, starting at the specified index of the target array.
            /// </summary>
            /// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the elements copied from the current collection. The array must have zero-based indexing.</param>
            /// <param name="index">The zero-based index in array at which copying begins.</param>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.layout.arrangedelementcollection.copyto(v=vs.110).aspx
            /// </remarks>
            public void CopyTo(Array array, int index)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Searches for controls by their <see cref="Name"/> property and builds an array of all the controls that match.
            /// </summary>
            /// <param name="key">The key to locate in the <see cref="ControlCollection"/>.</param>
            /// <param name="searchAllChildren">true to search all child controls; otherwise, false.</param>
            /// <returns>An array of type <see cref="Control"/> containing the matching controls.</returns>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.find(v=vs.110).aspx
            /// </remarks>
            public Control[] Find(string key, bool searchAllChildren)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Retrieves the index of the specified child control within the control collection.
            /// </summary>
            /// <param name="child">The <see cref="Control"/> to search for in the control collection.</param>
            /// <returns>A zero-based index value that represents the location of the specified child control within the control collection.</returns>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/1fz293fh(v=vs.110).aspx
            /// </remarks>
            public int GetChildIndex(Control child)
            {
                lock (_internalSyncRoot)
                {
                    if (_controls.Contains(child))
                    {
                        return _controls.IndexOf(child);
                    }

                    throw new KeyNotFoundException();
                }
            }

            /// <summary>
            /// Retrieves the index of the specified child control within the control collection, and optionally raises an exception if the specified control is not within the control collection.
            /// </summary>
            /// <param name="child">The <see cref="Control"/> to search for in the control collection.</param>
            /// <param name="throwException">true to throw an exception if the <see cref="Control"/> specified in the child parameter is not a control in the <see cref="ControlCollection"/>; otherwise, false.</param>
            /// <returns></returns>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/ta8fcz9s(v=vs.110).aspx
            /// </remarks>
            public virtual int GetChildIndex(Control child, bool throwException)
            {
                lock (_internalSyncRoot)
                {
                    if (_controls.Contains(child))
                    {
                        return _controls.IndexOf(child);
                    }

                    if (throwException)
                    {
                        throw new ArgumentException();
                    }

                    return -1;
                }
            }

            /// <summary>
            /// Retrieves a reference to an enumerator object that is used to iterate over a <see cref="ControlCollection"/>.
            /// </summary>
            /// <returns>An <see cref="IEnumerator"/>.</returns>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/ms158431(v=vs.110).aspx
            /// </remarks>
            public virtual IEnumerator GetEnumerator() => _controls.GetEnumerator();

            /// <summary>
            /// Retrieves the index of the specified control in the control collection.
            /// </summary>
            /// <param name="control">The <see cref="Control"/> to locate in the collection.</param>
            /// <returns>A zero-based index value that represents the position of the specified <see cref="Control"/> in the <see cref="ControlCollection"/>.</returns>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.indexof(v=vs.110).aspx
            /// </remarks>
            public int IndexOf(Control control)
            {
                lock (_internalSyncRoot)
                {
                    return _controls.IndexOf(control);
                }
            }

            /// <summary>
            /// Retrieves the index of the specified control in the control collection.
            /// </summary>
            /// <param name="key">The <see cref="Control"/> to locate in the collection.</param>
            /// <returns>A zero-based index value that represents the position of the specified <see cref="Control"/> in the <see cref="ControlCollection"/>.</returns>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.indexof(v=vs.110).aspx
            /// </remarks>
            public virtual int IndexOfKey(string key)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Removes the specified control from the control collection.
            /// </summary>
            /// <param name="value">The <see cref="Control"/> to remove from the <see cref="ControlCollection"/>.</param>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.remove(v=vs.110).aspx
            /// </remarks>
            public virtual void Remove(Control value)
            {
                lock (_internalSyncRoot)
                {
                    _controls.Remove(value);
                }
            }

            /// <summary>
            /// Removes a control from the control collection at the specified indexed location.
            /// </summary>
            /// <param name="index">The index value of the <see cref="Control"/> to remove.</param>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.removeat(v=vs.110).aspx
            /// </remarks>
            public void RemoveAt(int index)
            {
                lock (_internalSyncRoot)
                {
                    _controls.RemoveAt(index);
                }
            }

            /// <summary>
            /// Removes the child control with the specified key.
            /// </summary>
            /// <param name="key">The name of the child control to remove.</param>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.removebykey(v=vs.110).aspx
            /// </remarks>
            public virtual void RemoveByKey(string key)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Sets the index of the specified child control in the collection to the specified index value.
            /// </summary>
            /// <param name="child">The child <see cref="Control"/> to search for.</param>
            /// <param name="newIndex">The new index value of the control.</param>
            /// <remarks>
            /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.setchildindex(v=vs.110).aspx
            /// </remarks>
            public virtual void SetChildIndex(Control child, int newIndex)
            {
                lock (_internalSyncRoot)
                {
                    if (_controls.Contains(child))
                    {
                        if (newIndex >= Count)
                        {
                            _controls.Remove(child);
                            _controls.Add(child);
                        }
                        else
                        {
                            _controls.Remove(child);
                            _controls.Insert(newIndex, child);
                        }
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
            }
            #endregion

            #region Explicit Interface Implementations
            object ICloneable.Clone()
            {
                lock (_internalSyncRoot)
                {
                    ControlCollection clone = new ControlCollection(_owner, _controls);
                    return clone;
                }
            }

            bool ICollection.IsSynchronized { get { return true; } }
            object ICollection.SyncRoot { get { return _syncRoot; } }

            int IList.Add(object control)
            {
                var controlControl = control as Control;

                if (controlControl != null)
                {
                    lock (_internalSyncRoot)
                    {
                        InternalAdd(controlControl);

                        return _controls.Count;
                    }
                }

                return -1;
            }

            void IList.Clear()
            {
                Clear();
            }

            bool IList.Contains(object value)
            {
                var valueControl = value as Control;

                if (valueControl != null)
                {
                    return Contains(valueControl);
                }

                return false;
            }

            int IList.IndexOf(object value)
            {
                var valueControl = value as Control;

                if (valueControl != null)
                {
                    return IndexOf(valueControl);
                }

                return -1;
            }

            void IList.Insert(int index, object value)
            {
                var valueControl = value as Control;

                if (valueControl != null)
                {
                    lock (_internalSyncRoot)
                    {
                        _controls.Insert(index, valueControl);
                    }
                }
            }

            bool IList.IsFixedSize => false;

            object IList.this[int index]
            {
                get
                {
                    return this[index];
                }
                set
                {
                    var valueControl = value as Control;

                    if (valueControl != null)
                    {
                        lock (_internalSyncRoot)
                        {
                            _controls[index] = valueControl;
                        }
                    }
                }
            }

            void IList.Remove(object control)
            {
                var controlControl = control as Control;

                if (controlControl != null)
                {
                    Remove(controlControl);
                }
            }

            void IList.RemoveAt(int index)
            {
                RemoveAt(index);
            }
            #endregion
        }
    }
}
