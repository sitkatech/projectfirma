const list_data = [];
for (let i = 0; i < 100; i++) {
	list_data.push({
		value: "Item " + (i + 1)
	});
}

const dataview_data = [];
for (let i = 0; i < 100; i++) {
	dataview_data.push({
		value: "Item " + (i + 1)
	});
}

const tree_data = [];
for (let i = 0; i < 100; i++) {
	const obj = { value: "Folder " + (i + 1), items: [] };
	for (let j = 0; j < 4; j++) {
		obj.items.push({
			value: "Item " + (j + 1)
		});
	}
	tree_data.push(obj);
}

const grid_data = [];
for (let i = 0; i < 1000; i++) {
	grid_data.push({
		a: i + 1,
		value: "Item " + (i + 1),
	});
}

const treegrid_data = [];
for (let i = 0; i < 500; i++) {
	const obj = {
		a: i + 1,
		value: "Folder " + (i + 1),
		items: [],
	};
	for (let j = 0; j < 4; j++) {
		obj.items.push({
			a: j + 1,
			value: "Item " + (j + 1),
		});
	}
	treegrid_data.push(obj);
}
