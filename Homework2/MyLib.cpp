#define MYLIB_EXPORTS
#include "MyLib.h"
#include <vector>
#include <iostream>

struct Point{
    int x;
    int y;

    Point(int x_pos , int y_pos) : x(x_pos) , y(y_pos) {}
};

class PointManager{
    std::vector<Point> points;
public:

    PointManager(){}
    ~PointManager(){ points.clear(); }
    
    void AddPoint(int x, int y){ points.push_back(Point(x,y)); }

    void RemovePoint(int index){
        if(index >= Count() || index < 0){
            std::cout << "Invalid index\n";
            return;
        }
        points.erase(points.begin() + index);
    }

    void GetPoint(int index , int* x, int* y){
        if(index >= Count() || index < 0){
            std::cout << "Invalid index\n";
            return;
        }
        auto& point = points[index];
        *x = point.x;
        *y = point.y;
    }
    int Count(){ return points.size(); }
};

PointManager* CreatePointManager(){ return new PointManager(); }
void DeletePointManager(PointManager* pm){ delete pm; }

void AddPoint(PointManager* pm ,int x, int y) { 
    if(!pm) return;

    pm -> AddPoint(x,y);
}
void RemovePoint(PointManager* pm, int index) { 
    if(!pm) return;

    pm -> RemovePoint(index);
}
void GetPoint(PointManager* pm, int index, int* x, int* y){ 
    if(!pm) return;
  
    pm -> GetPoint(index, x, y);
};

int Count(PointManager* pm) { 
    if(!pm) return -1;
  
    return pm -> Count(); 
}
